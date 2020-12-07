using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    private List<Transform> targets;
    private GameObject[] playerlist;
    public Vector3 offset;
    private Vector3 velocity;
    public Camera cam; 

    public float smoothTime = 0.5f;
    public float maxZoom = 6f;
    public float minZoom = 4f;
    public float zoomLimit = 26f;

    private void Start()
    {
        offset.z = -10f;
        playerlist = PlayerManager.getPlayerlist();
        targets = new List<Transform>();
    }

    private void OnEnable()
    {
        PlayerManager.OnPlayerListChange += UpdateTargets;

    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerListChange -= UpdateTargets;
    }

    private void UpdateTargets()
    {
        GameObject[] newPlayerlist = PlayerManager.getPlayerlist();
        if (!playerlist.Equals(newPlayerlist))
        {
            playerlist = newPlayerlist; 
            if(playerlist.Length > 0)
            {
                Debug.Log(playerlist.Length);
                targets = new List<Transform>(playerlist.Length);
                for (int i = 0; i < playerlist.Length; i++)
                {
                    targets.Add(playerlist[i].transform);
                    Debug.Log("target" + playerlist[i].name + playerlist[i].GetInstanceID());
                }
            }
        }
        
    }

    private void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return; 
        }
        moveCamara();
        zoomCamara();
    }

    void zoomCamara()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimit);
        cam.fieldOfView = newZoom;
    }

    float GetGreatestDistance()
    {
        if(targets.Count == 0)
        {
            return 0f;
        }
        var bounds = new Bounds(targets[0].position,Vector2.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        } 
        return bounds.size.x;
    }

    void moveCamara()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 withOffset = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, withOffset, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        //Debug.Log(targets.Count);
        if (targets.Count == 0)
        {
            return new Vector3(0,0,0);
        } else if (targets.Count == 1){
            return targets[0].position;
        } else {
            Bounds bounds = new Bounds(targets[0].position, Vector2.zero);
            for (int i = 0; i < targets.Count; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.center;
        }
    }
}

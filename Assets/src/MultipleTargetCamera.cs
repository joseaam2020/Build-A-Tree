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
    private int indice;
    private bool updated;

    private void Start()
    {
        offset.z = -10f;
        playerlist = PlayerManager.getPlayerlist();
        targets = new List<Transform>();
        updated = false; 
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
        playerlist = PlayerManager.getPlayerlist();
        indice = 0;
        foreach (GameObject newPlayer in playerlist)
        {
            Debug.Log("Done");
            if (newPlayer.activeSelf)
            {
                Debug.Log(newPlayer.transform);
                PlayerHub playerhub = newPlayer.GetComponent(typeof(PlayerHub)) as PlayerHub;
                Transform child = newPlayer.transform.FindChild(playerhub.getActiveModel());
                targets.Add(child);
                indice++;
            }
        }
        updated = true;
    }

    private void LateUpdate()
    {
        if (updated)
        {
            if (indice == 0)
            {
                return;
                Debug.Log("Es cero");
            }
            moveCamara();
            zoomCamara();
        }
    }
       

    void zoomCamara()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimit);
        cam.fieldOfView = newZoom;
    }

    float GetGreatestDistance()
    {
        if(indice == 0)
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
        if (indice == 0)
        {
            return new Vector3(0,0,0);
        } else if (indice == 1){
            Debug.Log(targets[0].position);
            return targets[0].position;
        } else {
            Debug.Log(targets.Count);
            Debug.Log(indice );
            Bounds bounds = new Bounds(targets[0].position, Vector2.zero);
            for (int i = 0; i < indice; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.center;
        }
    }
}

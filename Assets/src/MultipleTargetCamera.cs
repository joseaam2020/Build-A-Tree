using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;
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
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds   bounds = new Bounds(targets[0].position,Vector2.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        } 
        return bounds.center;
    }
}

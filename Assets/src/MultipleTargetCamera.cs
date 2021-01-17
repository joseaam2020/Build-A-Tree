using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase se encarga de la camara en la escena de juego.
/// Fue creada a partir de una clase tomada como referencia. 
/// Brackeys,"MULTIPLE TARGET CAMERA in Unity", Youtube, 17-Dec-2017.[Online].Available: https://www.youtube.com/watch?v=aLpixrPvlB8.
/// [Accesed: 13-Dec-2020]
/// </summary>
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

    /// <summary>
    /// Obtiene lso objetos jugdor del PlayerManager y los conecta a la camara
    /// </summary>
    private void UpdateTargets()
    {
        playerlist = PlayerManager.getPlayerlist();
        indice = 0;
        foreach (GameObject newPlayer in playerlist)
        {
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

    /// <summary>
    /// Mueve la camara
    /// </summary>
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
       
    /// <summary>
    /// Calcula la distancia a la cual la camara esta de los objetos segun cuan separados estan
    /// </summary>
    void zoomCamara()
    {
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimit);
        cam.fieldOfView = newZoom;
    }

    /// <summary>
    /// Calcula la mayor distancia entre los objetos.
    /// </summary>
    /// <returns>La mayor distancia entres lso objetos como float</returns>
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

    /// <summary>
    /// Mueve la camara segun la posicion de los objetos
    /// </summary>
    void moveCamara()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 withOffset = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, withOffset, ref velocity, smoothTime);
    }

    /// <summary>
    /// Calcula el centro de un rectangulo que encierra a todos los objetos
    /// </summary>
    /// <returns>El punto central entre los objetos como un Vector3</returns>
    Vector3 GetCenterPoint()
    {
        if (indice == 0)
        {
            return new Vector3(0,0,0);
        } else if (indice == 1){
            return targets[0].position;
        } else {
            Bounds bounds = new Bounds(targets[0].position, Vector2.zero);
            for (int i = 0; i < indice; i++)
            {
                bounds.Encapsulate(targets[i].position);
            }
            return bounds.center;
        }
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

/// <summary>
/// Clase recibe los personajes creados en el menu de seleccion y los conecta a los controles dentro de la escena juego.
/// </summary>
public class PlayerManager : MonoBehaviour
{

    public static GameObject[] playerlist;
    public delegate void playerListChanged();
    public static event playerListChanged OnPlayerListChange;
    public GameObject PlayerHubPrefab;
    public GameObject ClientPrefab;

    /// <summary>
    /// Asegura que no ocurren errores añadiendo un void a el evento OnPlayerListChange
    /// </summary>
    public void nada()
    {
        return;
    }

    private void OnEnable()
    {
        OnPlayerListChange += nada;
        SceneManager.activeSceneChanged += OnSceneLoaded;
    }

    private void OnDisable()
    {
        OnPlayerListChange -= nada;
        SceneManager.activeSceneChanged -= OnSceneLoaded;
    }

    /// <summary>
    /// En el cambio de escena, si la nueva escena es juego, se incian los jugadores.
    /// </summary>
    /// <param name="current">Escena actual</param>
    /// <param name="next">Siguiente Escena</param>
    public void OnSceneLoaded(Scene current, Scene next)
    {
        Debug.Log("current: " + current.name + ",next: " + next.name);
        if (next.name == "Game")
        {
            //Conseguir player manager
            PlayerInputManager inputManager = this.gameObject.GetComponent(typeof(PlayerInputManager)) as PlayerInputManager;
            //Hacer Player Join en el Player Manager
            List<string> activeModels = new List<string>();
            foreach (GameObject player in playerlist)
            {
                //Crear nuevo PlayerHub, dar a cada uno de los jugadores los assets
                GameObject newPlayer = PlayerHubPrefab;
                PlayerHub oldPlayerHub = player.GetComponent(typeof(PlayerHub)) as PlayerHub;
                activeModels.Add(oldPlayerHub.getActiveModel());
                PlayerInput newInput = newPlayer.GetComponent(typeof(PlayerInput)) as PlayerInput;
                PlayerInput oldInput = player.GetComponent(typeof(PlayerInput)) as PlayerInput;
                newInput.actions = oldInput.actions;
                newInput.currentActionMap = oldInput.currentActionMap;
                InputDevice device = oldInput.devices[0];
                //Añadir PLayerHub por PlayerManager
                inputManager.playerPrefab = newPlayer;
                inputManager.JoinPlayer(-1, -1, oldInput.currentControlScheme, device);
                player.tag = "NotPlayer";
                Destroy(player);
            }
            playerlist = GameObject.FindGameObjectsWithTag("Player");
            int counter = 0;
            foreach (GameObject player in playerlist)
            {
                player.transform.position = new Vector3(0, 0, -1);
                PlayerHub newPlayerHub = player.GetComponent(typeof(PlayerHub)) as PlayerHub;
                if(counter >= activeModels.Count)
                {
                    counter = 0;
                }
                player.name = counter.ToString();
                foreach (GameObject model in newPlayerHub.modelList)
                {
                    TextMeshPro playerTag = model.GetComponentInChildren(typeof(TextMeshPro)) as TextMeshPro;
                    playerTag.text = "Player " + (counter + 1).ToString();
                }
                newPlayerHub.setActiveModel(activeModels[counter]);
                counter++;
            }
            Invoke("Changed",1);
        }
    }

    /// <summary>
    /// Cuando se asegura que se cargan los personajes, se llama evento OnPlayerListChange. 
    /// Tambien se incia el cliente del serverdor. 
    /// </summary>
    public void Changed()
    {
        OnPlayerListChange();
        Instantiate(ClientPrefab);
    }

    /// <summary>
    /// Retorna la lista de jugadores ingresados y cargados en juego. 
    /// </summary>
    /// <returns>Lista de jugadores como GameObject[]</returns>
    public static GameObject[] getPlayerlist()
    {
        return playerlist;
    }

    private void Awake()
    {
        playerlist = GameObject.FindGameObjectsWithTag("Player");
    }

    /// <summary>
    /// Obtiene los nuevos jugadores
    /// </summary>
    private void Update()
    {
        GameObject[] newPlayerlist = GameObject.FindGameObjectsWithTag("Player");
        int actualLength = playerlist.Length;
        int newLength = newPlayerlist.Length;
        if (actualLength < newLength)
        {
            playerlist = newPlayerlist;
        }
    }
}

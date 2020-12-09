 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{

    public static GameObject[] playerlist;
    public delegate void playerListChanged();
    public static event playerListChanged OnPlayerListChange;
    public GameObject PlayerHubPrefab;
    public GameObject ClientPrefab;


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
                //ebug.Log(player.name);
                player.transform.position = new Vector3(0, 0, -1);
                PlayerHub newPlayerHub = player.GetComponent(typeof(PlayerHub)) as PlayerHub;
                if(counter >= activeModels.Count)
                {
                    counter = 0;
                }
                player.name = counter.ToString(); 
                newPlayerHub.setActiveModel(activeModels[counter]);
                counter++;
            }
            Invoke("Changed",1);
        }
    }

    public void Changed()
    {
        OnPlayerListChange();
        Instantiate(ClientPrefab);
    }

    public static GameObject[] getPlayerlist()
    {
        return playerlist;
    }

    private void Awake()
    {
        playerlist = GameObject.FindGameObjectsWithTag("Player");
    }

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

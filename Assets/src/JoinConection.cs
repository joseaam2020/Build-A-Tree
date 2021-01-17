using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase encargada de conectar personajes a los controles una vez empezado el juego.
/// </summary>
public class JoinConection : MonoBehaviour
{

    [SerializeField] public PlayerSelection[] allSelectors;
    public static GameObject[] allPlayers;
    private InputControl inputControl;
    public static int readyPlayers;
    private int counter = 0;
    private static int playerCounter = 0;
    private bool doneReady;
    
    public static int getplayerCounter()
    {
        return playerCounter;
    }

    private void Awake()
    {
        allPlayers = new GameObject[4];
        inputControl = new InputControl();
        doneReady = false;
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    /// <summary>
    /// Añade un nuevo jugador al atributo allPLayers, que contiene a todos los jugadores por ingresar
    /// </summary>
    /// <param name="newPlayer"></param>
    public static void addPlayer(GameObject newPlayer)
    {
        for(int i = 0; i < allPlayers.Length; i++)
        {
            if(allPlayers[i] == null)
            {
                allPlayers[i] = newPlayer;
                break;
            }
        }
    }

    /// <summary>
    /// Al ingresar un control por medio del PlayerManager,
    /// conecta el jugador a su seleccionador en el menu para seleccionar un personaje
    /// </summary>
    void OnPlayerJoined()
    {
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        int actualCounter = playerlist.Length;
        if (playerCounter != actualCounter)
        {
            //Debug.Log("Playercounter " + playerCounter 
              //         + ",actualCounter " + actualCounter
                //       + ",counter " + counter 
                  //     + "name" + allSelectors[counter].name);
            playerCounter = actualCounter;
            allSelectors[counter].onJoin(counter);
            counter += 1;
        }
    }

    /// <summary>
    /// Se encarga de verificar si los jugadores estan listos
    /// </summary>
    private void Update()
    {
        if(readyPlayers == playerCounter && playerCounter > 0)
        {
            if (!doneReady)
            {
                ReadySetup();
                doneReady = true;
            }
        }
    }

    /// <summary>
    /// Conecta a todod los controles a los personajes seleccionados y los guarda para la siguiente escena.
    /// Carga la siguiente escena.
    /// </summary>
    private void ReadySetup()
    {
        
        int selectorCounter = 0;
        foreach (GameObject player in allPlayers)
        {
            if(player != null)
            {
                //Dar a todos los playerhubs el action set
                PlayerInput input = player.GetComponent<PlayerInput>();
                InputDevice device = input.devices[0];
                InputUser user = input.user;
                input.defaultControlScheme = "Gamepad";
                input.defaultActionMap = "PLayer";
                input.actions = inputControl.asset;
                InputUser.PerformPairingWithDevice(device, user);
                input.SwitchCurrentControlScheme(device);
               
                //Habilitar el modelo seleccionado
                PlayerHub hub = player.GetComponent<PlayerHub>();
                PlayerSelection selector = allSelectors[selectorCounter];
                hub.setActiveModel(selector.getSelectedModel());
                selectorCounter++;

                //Hacer que todos los playerhubs pasen a la siguiente escena
                DontDestroyOnLoad(player);
            }
        }
        //Cambio de escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Aqui se carga la escena juego, puede conseguir numero de jugadores con playerCounter
    }
}

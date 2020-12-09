using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using TMPro;
public class PlayerSelection : MonoBehaviour
{

    [SerializeField] public GameObject[] modelList;
    [SerializeField] public GameObject[] textList;
    [SerializeField] public GameObject[] imageHolder;

    private int indice;
    private InputControl inputControl;
    private bool ready;
    private void Awake()
    {
        inputControl = new InputControl();
        textList[0].SetActive(true);
        textList[1].SetActive(false);
        textList[2].SetActive(false);
        textList[3].SetActive(false);
        foreach(GameObject image in imageHolder)
        {
            image.SetActive(false);
        }
        indice = 0;
        foreach(GameObject model in modelList)
        {
            model.SetActive(false);
        } modelList[indice].SetActive(true);
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }
    public void onJoin(int counter)
    {
        //Debug.Log("Inicio de seleccion");

        //Conectar el control al seleccionador
        
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        JoinConection.addPlayer(playerlist[counter]);
        if (playerlist.Length > 0)
        {
            PlayerInput input = this.gameObject.AddComponent(typeof(PlayerInput)) as PlayerInput;
            input.user.AssociateActionsWithUser(inputControl);
            PlayerInput playerInput = playerlist[counter].GetComponent<PlayerInput>();
            InputDevice device = playerInput.devices[0];
            InputUser.PerformPairingWithDevice(device, input.user);
           // Debug.Log(inputControl.controlSchemes.ToArray()[0].ToString());
           // Debug.Log(device.name);
            input.defaultControlScheme = "Gamepad";
            input.defaultActionMap = "UI";
            input.actions = inputControl.asset;
            input.SwitchCurrentControlScheme(device);
        }
        ;

        //Cambiar de presionar boton a seleccion de personaje
        textList[0].SetActive(false);
        textList[1].SetActive(true);
        textList[2].SetActive(true);
        foreach (GameObject image in imageHolder)
        {
            image.SetActive(true);
        }
    } 

    public void OnPress()
    {
        //Debug.Log("Press done");
        //Cambia de personaje seleccionado
        if (!ready)
        {
            int cambio = (int)inputControl.UI.Press.ReadValue<float>();
            modelList[indice].SetActive(false);
            indice += cambio;
            if (indice < 0)
            {
                indice = 3;
            }
            else if (indice > 3)
            {
                indice = 0;
            }
            modelList[indice].SetActive(true);
        }
    }


    public void OnReady()
    {
        if (!ready)
        {
            Debug.Log("Ready");
            //Deshabilitar seleccion
            ready = true;
            //Aumentar contador de jugadores ready
            JoinConection.readyPlayers++;
            //Indicar en el Menu
            textList[2].SetActive(false);
            textList[3].SetActive(true);
        }
    }

    public void OnNotReady()
    {

        if (ready)
        {
            //Habiliat seleccion
            ready = false;
            //Quitar al contador de jugadore
            JoinConection.readyPlayers--;
            //Indice en el Menu
            textList[3].SetActive(false);
            textList[2].SetActive(true);
        }
    }

    public string getSelectedModel()
    {
        return modelList[indice].name;
    }
 
}

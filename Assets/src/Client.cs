using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TMPro;
using System;

public class Client : MonoBehaviour
{
    private Socket clientSocket;
    private IPEndPoint serverAddress;
    private static Client instance;
    private Thread listen;

    private GameObject timer;
    private TextMeshProUGUI time;
    private string newTime = "";

    public GameObject tokenSpawnerPrefab;
    private tokenSpawner spawner;
    private bool SpawnAVL = false;
    private bool SpawnB = false;
    private bool SpawnBST = false;
    private bool SpawnSPLAY = false;
    public string currentTree;
    public int maxTokenValue;
    public bool arbolActualizado = false;

    public GameObject[] datosJugador;
    public bool llamadaTree = false;
   
    void Awake()
    {
        listen = new Thread(Listener);

        datosJugador = GameObject.FindGameObjectsWithTag("DatosJugador");

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        listen.Start();
        SendMSG("GETCHALLENGE#1");       

        timer = GameObject.FindGameObjectWithTag("Timer");
        time = timer.gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;

        var TokenSpawner = Instantiate(tokenSpawnerPrefab);
        spawner = TokenSpawner.gameObject.GetComponent(typeof(tokenSpawner)) as tokenSpawner;

    }

    private void Update()
    {
        if (llamadaTree)
        {
            foreach (GameObject datos in datosJugador)
            {
                DatosJugador script = datos.GetComponent<DatosJugador>();
                script.setActiveArbol(currentTree);
                TextMeshPro textoArbol = datos.GetComponentInChildren<TextMeshPro>();
                textoArbol.text = currentTree;
            } llamadaTree = false;
        }

        time.SetText(newTime);

        if (SpawnAVL)
        {
            spawner.Spawn("AVL Tree", UnityEngine.Random.Range(0, maxTokenValue));
            SpawnAVL = false;
        }
        if (SpawnB)
        {
            spawner.Spawn("B Tree", UnityEngine.Random.Range(0, maxTokenValue));
            SpawnB = false;
        }
        if (SpawnBST)
        {
            spawner.Spawn("BST Tree", UnityEngine.Random.Range(0, maxTokenValue));
            SpawnBST = false;
        }
        if (SpawnSPLAY)
        {
            spawner.Spawn("Splay Tree", UnityEngine.Random.Range(0, maxTokenValue));
            SpawnSPLAY = false;
        }
    }

    private void OnDisable()
    {
        listen.Suspend();
    }

    public static Client getInstance()
    {
        return instance;
    }



    public void Listener()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5100);
        clientSocket.Connect(serverAddress);
        //Send("GETCHALLENGE#1");
        while (true)
        {
            // Recibir

            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            string rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            string[] split = rcv.Split('#');

            //CONDICIONES PARA EL SPLIT
            if (split[0] == "CHALLENGETIME")
            {
                newTime = split[1];
            }
            if (split[0] == "SPAWNER")
            {
                if(split[1]== "AVL")
                {
                    SpawnAVL = true;
                }
                if (split[1] == "B")
                {
                    SpawnB = true;
                }
                if (split[1] == "BST")
                {
                    SpawnBST = true;
                }
                if (split[1] == "SPLAY")
                {
                    SpawnSPLAY = true;
                }
            }
            if (split[0] == "TREE")
            {
                Debug.Log("Done");
                currentTree = split[1];
                maxTokenValue = Int32.Parse(split[2]);
                llamadaTree = true;
            }

            //Debug.Log("Client received: " + rcv);

        }
    }

    public void SendMSG(string toSend)
    {

        listen.Abort();

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5100);
        clientSocket.Connect(serverAddress);

        // Sending
        int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
        byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
        byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
        clientSocket.Send(toSendLenBytes);
        clientSocket.Send(toSendBytes);
        Debug.Log("Mensaje Enviado: " + toSend);

        Thread newListen = new Thread(Listener);
        newListen.Start();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using TMPro;

public class Client : MonoBehaviour
{
    private Socket clientSocket;
    private IPEndPoint serverAddress;
    private static Client instance;
    private Thread listen;

    public GameObject timer;
    private TextMeshProUGUI time;
    private string newTime = "";
   
    void Awake()
    {
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
        SendMSG("GETCHALLENGE#1");       
        listen = new Thread(Listener);
        listen.Start();

        timer = GameObject.FindGameObjectWithTag("Timer");
        time = timer.gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
    }

    private void Update()
    {
        time.SetText(newTime);
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

                }
            }
            if (split[0] == "TREE")
            {

            }
            if (split[0] == "CWINNER")
            {

            }

            Debug.Log("Client received: " + rcv);

        }
    }

    public void SendMSG(string toSend)
    {
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
    }

}
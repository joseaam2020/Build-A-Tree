using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Net;
using System.Net.Sockets;

public class ClientSocket : MonoBehaviour
{
    private Socket clientSocket;
    private IPEndPoint serverAddress;
    private static ClientSocket instance;

    private ClientSocket() { }

    // Start is called before the first frame update
    void Start()
    {
        Thread listen = new Thread(Listener);
        listen.Start();
    }

    public ClientSocket getInstance()
    {
        if (instance == null)
        {
            instance = new ClientSocket();
        }
        return instance;
    }

    public void Listener()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5100);
        clientSocket.Connect(serverAddress);
        while (true)
        {
            // Recibir

            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            string rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Debug.Log("Client received: " + rcv);

        }
    }
}

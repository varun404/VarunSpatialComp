using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

public class TCPServer : MonoBehaviour
{
    private TcpListener tcpListener;
    private TcpClient connectedClient;
    private NetworkStream networkStream;
    private byte[] receiveBuffer;

    private void Start()
    {
        // Example: Start the server on port 5555
        StartServer(5555);
    }

    private void StartServer(int port)
    {
        tcpListener = new TcpListener(IPAddress.Any, port);
        tcpListener.Start();

        Debug.Log("Server started. Waiting for connections...");

        // Start accepting client connections asynchronously
        tcpListener.BeginAcceptTcpClient(HandleIncomingConnection, null);
    }

    private void HandleIncomingConnection(IAsyncResult ar)
    {
        Debug.Log(ar.AsyncState);
        throw new NotImplementedException();
    }


}
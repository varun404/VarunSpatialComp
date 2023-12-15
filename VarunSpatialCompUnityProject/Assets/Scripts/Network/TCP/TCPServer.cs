using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UnityEngine;

public class TCPServer : MonoBehaviour
{

    public static Action<string> OnReceivedUpdateFromClient;


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


    private void HandleIncomingConnection(IAsyncResult result)
    {
        connectedClient = tcpListener.EndAcceptTcpClient(result);
        networkStream = connectedClient.GetStream();

        Debug.Log("Client connected: " + connectedClient.Client.RemoteEndPoint);

        // Start asynchronous operation to receive data from the client
        receiveBuffer = new byte[connectedClient.ReceiveBufferSize];
        networkStream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, ReceiveData, null);

        // Accept next client connection asynchronously
        tcpListener.BeginAcceptTcpClient(HandleIncomingConnection, null);
    }


    private void ReceiveData(IAsyncResult result)
    {
        int bytesRead = networkStream.EndRead(result);
        if (bytesRead <= 0)
        {
            Debug.Log("Client disconnected: " + connectedClient.Client.RemoteEndPoint);
            connectedClient.Close();
            return;
        }

        byte[] receivedBytes = new byte[bytesRead];
        Array.Copy(receiveBuffer, receivedBytes, bytesRead);

        string receivedMessage = System.Text.Encoding.UTF8.GetString(receivedBytes);
        Debug.Log("Received from client: " + receivedMessage);

        // Process received data
       

        // Continue the asynchronous operation to receive data
        networkStream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, ReceiveData, null);
        OnReceivedUpdateFromClient?.Invoke(receivedMessage);
    }


    private void SendData(string message)
    {
        byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(message);
        networkStream.Write(sendBytes, 0, sendBytes.Length);
        networkStream.Flush();

        Debug.Log("Sent to client: " + message);
    }
}
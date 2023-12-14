using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class TCPClient : MonoBehaviour
{
    private TcpClient tcpClient;
    private NetworkStream networkStream;
    private byte[] receiveBuffer;

    private void Start()
    {
        // Example: Connect to server with IP address 127.0.0.1 (localhost) and port 5555
        ConnectToServer("127.0.0.1", 5555);
    }

    private void ConnectToServer(string ipAddress, int port)
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(IPAddress.Parse(ipAddress), port);
        networkStream = tcpClient.GetStream();

        // Start asynchronous operation to receive data from the server
        receiveBuffer = new byte[tcpClient.ReceiveBufferSize];
        networkStream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, ReceiveData, null);
    }

    private void ReceiveData(IAsyncResult result)
    {
        int bytesRead = networkStream.EndRead(result);
        byte[] receivedBytes = new byte[bytesRead];
        Array.Copy(receiveBuffer, receivedBytes, bytesRead);

        string receivedMessage = System.Text.Encoding.UTF8.GetString(receivedBytes);
        Debug.Log("Received from server: " + receivedMessage);

        // Continue the asynchronous operation to receive data
        networkStream.BeginRead(receiveBuffer, 0, receiveBuffer.Length, ReceiveData, null);
    }

    private void SendData(string message)
    {
        byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes(message);
        networkStream.Write(sendBytes, 0, sendBytes.Length);
        networkStream.Flush();
    }
}

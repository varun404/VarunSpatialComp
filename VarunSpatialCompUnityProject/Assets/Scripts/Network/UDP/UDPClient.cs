using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPClient : MonoBehaviour
{
    private const int listenPort = 11000;
    UdpClient listener = new UdpClient(listenPort);
    IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
    void Start()
    {
        Thread thread = new Thread(Receive);
        thread.Start();
    }

    private void Receive()
    {
        try
        {
            while (true)
            {
                print("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref groupEP);

                print($"Received broadcast from {groupEP} :");
                print($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");

            }
        }
        catch (SocketException e)
        {
            print(e);
        }
    }
    private void OnDestroy()
    {
        listener.Close();
    }
}

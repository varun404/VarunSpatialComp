using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPServer : MonoBehaviour
{
    [SerializeField]
    string targetIPAddress = "172.26.98.224"; // Classroom computer's ipaddress

    [SerializeField]
    int portNumber = 5000;




    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        Send("test test test");
    }
    private void Send(string msg)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress targetAddress = IPAddress.Parse(targetIPAddress);

        IPEndPoint ep = new IPEndPoint(targetAddress, portNumber);


        byte[] sendbuf = Encoding.ASCII.GetBytes(msg);

        s.SendTo(sendbuf, ep); s.Close();

        print("Message sent");
    }


}

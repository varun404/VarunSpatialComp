using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class ArduinoConnectionManager : MonoBehaviour
{
    SerialPort dataStream = new SerialPort("COM NUMBER", 19200);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

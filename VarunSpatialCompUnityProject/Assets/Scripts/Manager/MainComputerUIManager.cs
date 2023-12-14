using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainComputerUIManager : MonoBehaviour
{
    [SerializeField]
    Image lock1Image, lock2Image, lock3Image;



    // Start is called before the first frame update
    void Start()
    {
        UDPServer.OnReceivedUpdateFromClient += ProcessUpdate;
    }
    


    void ProcessUpdate(string updateFromClient)
    {
        switch (updateFromClient)
        {
            case "StartBook":
                lock1Image.color = Color.green;
                break;

            case "StartFormula":
                lock2Image.color = Color.green;
                break;

            case "AllDone":
                lock3Image.color = Color.green;
                break;

            default:
                break;
        }
    }

}

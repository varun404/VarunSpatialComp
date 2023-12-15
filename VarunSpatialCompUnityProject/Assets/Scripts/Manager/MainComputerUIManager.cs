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
        TCPServer.OnReceivedUpdateFromClient += ProcessUpdate;
    }
    


    public void ProcessUpdate(string updateFromClient)
    {
        Debug.Log("Processing");
        switch (updateFromClient)
        {
            case "StartBook":
                lock1Image.color = new Color(0, 1f, 0);
                break;

            case "StartFormula":
                lock2Image.color = new Color(0, 1, 0);
                break;

            case "AllDone":
                lock3Image.color = new Color(0, 1f, 0);
                break;

            default:
                break;
        }
    }

}

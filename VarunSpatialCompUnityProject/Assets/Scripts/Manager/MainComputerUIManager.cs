using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainComputerUIManager : MonoBehaviour
{
    [SerializeField]
    Image lock1Image, lock2Image, lock3Image;


    [SerializeField]
    GameObject fakeTerminal;


    // Start is called before the first frame update
    void Start()
    {
        
        TCPServer.OnReceivedUpdateFromClient += ProcessUpdate;
    }


    bool isAllDone;
    private void Update()
    {
        if (isAllDone)
            gameObject.SetActive(false);
    }



    private void OnDisable()
    {
        TCPServer.OnReceivedUpdateFromClient -= ProcessUpdate;
    }

    public void ProcessUpdate(string updateFromClient)
    {        
        switch (updateFromClient)
        {
            case "StartBook":
                Debug.Log("Processing");
                lock1Image.color = new Color(0, 1f, 0);
                break;

            case "StartFormula":
                Debug.Log("Processing");
                lock2Image.color = new Color(0, 1, 0);
                break;

            case "AllDone":
                Debug.Log("All Done bro");

                isAllDone = true;

                lock3Image.color = new Color(0, 1f, 0);
                break;

            default:
                break;
        }
    }

}

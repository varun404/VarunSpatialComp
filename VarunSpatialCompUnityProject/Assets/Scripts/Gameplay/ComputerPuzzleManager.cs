using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPuzzleManager : MonoBehaviour
{

    [SerializeField]
    FakeTerminal fakeTerminal;



    [SerializeField]
    MainComputerUIManager mainComputerUIManager;

    //[SerializeField]
    //TCPClient tcpClient;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        FakeTerminal.OnPasswordAuthenticated += OnPasswordAuthenticated;
        FakeTerminal.OnBookAuthenticated += OnBookAuthenticated;
        FakeTerminal.OnMathProblemAuthenticated += OnMathProblemAuthenticated;

        yield return new WaitForSeconds(8);

        FindObjectOfType<PlayerHandHeldDevice>().ChangeDeviceTarget(1);
    }

   
    public string[] whatAfterPasswordAuthenticated;
    void OnPasswordAuthenticated()
    {
        foreach (string line in whatAfterPasswordAuthenticated)
        {
            fakeTerminal.AddLineToList(line);
        }

        mainComputerUIManager.ProcessUpdate("StartBook");        
        //Send info for 2nd clue
        //tcpClient.SendData("StartBook");

    }



    public string[] whatAfterBookAuthenticated;
    void OnBookAuthenticated()
    {
        foreach (string line in whatAfterBookAuthenticated)
        {
            fakeTerminal.AddLineToList(line);
        }


        mainComputerUIManager.ProcessUpdate("StartFormula");
        //Send info for 3rd clue
        //tcpClient.SendData("StartFormula");

    }



    public string[] whatAfterMathProblemAuthenticated;
    void OnMathProblemAuthenticated()
    {
        fakeTerminal.AddLineToList("Welcome Dr. Lusso! Unlocking main computer..");

        mainComputerUIManager.ProcessUpdate("AllDone");

        //Send info for what to do after all clues are found.
        //tcpClient.SendData("AllDone");
    }
}

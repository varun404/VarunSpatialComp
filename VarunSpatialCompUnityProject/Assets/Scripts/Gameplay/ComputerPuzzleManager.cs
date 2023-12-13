using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPuzzleManager : MonoBehaviour
{

    [SerializeField]
    FakeTerminal fakeTerminal;

    // Start is called before the first frame update
    void Start()
    {
        FakeTerminal.OnPasswordAuthenticated += OnPasswordAuthenticated;
        FakeTerminal.OnBookAuthenticated += OnBookAuthenticated;
        FakeTerminal.OnMathProblemAuthenticated += OnMathProblemAuthenticated;
    }

   
    public string[] whatAfterPasswordAuthenticated;
    void OnPasswordAuthenticated()
    {
        foreach (string line in whatAfterPasswordAuthenticated)
        {
            fakeTerminal.AddLineToList(line);
        }        
    }



    public string[] whatAfterBookAuthenticated;
    void OnBookAuthenticated()
    {
        foreach (string line in whatAfterBookAuthenticated)
        {
            fakeTerminal.AddLineToList(line);
        }
    }



    public string[] whatAfterMathProblemAuthenticated;
    void OnMathProblemAuthenticated()
    {
        foreach (string line in whatAfterMathProblemAuthenticated)
        {
            fakeTerminal.AddLineToList(line);
        }
    }
}

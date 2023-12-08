using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrippedFakeTerminal : MonoBehaviour
{
    public List<CustomText> custom_Inputs;
    
    public string admin_Password;
    
    public string[] inputs_Clear;
    
    
    public string[] text_Error;
    public string[] text_AccessDenied;
    public string[] text_AccessGranted;



    public int text_MaxStringsOnScreen;

    public int text_MaxCharsInString;

    public char cursor_Char;

    public float cursor_BlinkingTime;
    




    private int actualLine;
    private int fakeLine;


    private string originalPassword;

    private bool terminalIsRunning;
    private bool terminalStarting;
    private bool terminalIsIdling;
    private bool cursorVisible;

    // Start is called before the first frame update
    void Start()
    {
        if (("" + cursor_Char) == " ")
        {
            cursor_Char = '█';
        }

        originalPassword = admin_Password;

        actualLine = 0;
        fakeLine = 0;

        cursorVisible = false;

        terminalIsIdling = true;
        terminalStarting = false;
        terminalIsRunning = false;

        originalPassword = admin_Password;

        actualLine = 0;
        fakeLine = 0;

        cursorVisible = false;

        terminalIsIdling = true;
        terminalStarting = false;
        terminalIsRunning = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class CustomText
{
    public string[] text_Input;
}

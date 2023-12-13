using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrippedFakeTerminal : MonoBehaviour
{
    public bool isFakeTerminalActive;



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

    
    
    private List<string> outputText = new List<string>();
    private Text screen;

    //  Just esthetics. It's a sequential number shown in each line.
    private string lineIntro;


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

        screen = this.GetComponent<Text>();

        StartCoroutine("TerminalIdlingCursor");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(isFakeTerminalActive && terminalIsIdling)
        {
            terminalIsIdling = false;
            terminalStarting = true;
            terminalIsRunning = true;


            StartCoroutine("TerminalStart");
            StartCoroutine("TerminalRunningCursor");
        }

        if (!terminalStarting && terminalIsRunning)
        {
            //TerminalInput();
        }
    }




    //private void TerminalInput()
    //{
    //    foreach (char c in Input.inputString)
    //    {
    //        if (c == '\b') //   Has backspace/delete been pressed?
    //        {
    //            if (outputText[actualLine].Length > lineIntro.Length)
    //            {
    //                if (outputText[actualLine].Contains("" + cursor_Char) && outputText[actualLine].Length > lineIntro.Length + 1)
    //                {
    //                    outputText[actualLine] = outputText[actualLine].Substring(0, outputText[actualLine].Length - 2) + cursor_Char;
    //                }
    //                else if (!outputText[actualLine].Contains("" + cursor_Char))
    //                {
    //                    outputText[actualLine] = outputText[actualLine].Substring(0, outputText[actualLine].Length - 1);
    //                }
    //            }
    //        }
    //        else if ((c == '\n') || (c == '\r')) // Has enter/return been pressed?
    //        {
    //            if (outputText[actualLine].Contains("" + cursor_Char))
    //            {
    //                string temp = "";
    //                foreach (char letter in outputText[actualLine])
    //                {
    //                    if (letter != cursor_Char)
    //                        temp += letter;
    //                }
    //                outputText[actualLine] = temp;
    //            }

    //            if (!logged && admin_RequestLogin)
    //            {
    //                if (text_ForceCapsLock)
    //                {
    //                    outputText[actualLine] = outputText[actualLine].ToUpper();
    //                }

    //                if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == admin_Password)
    //                {
    //                    logged = true;
    //                    PrintAccessGranted();
    //                }
    //                else
    //                {
    //                    PrintAccessNegate();
    //                }
    //            }
    //            else
    //            {
    //                bool printError = true;

    //                if (outputText[actualLine].Replace("" + cursor_Char, "").Length > lineIntro.Length)
    //                {
    //                    //----//

    //                    // ADD HERE NEW CUSTOM COMMANDS

    //                    // EXAMPLE:

    //                    // [...]
    //                    //
    //                    //  foreach(string input_Example in inputs_Example)
    //                    //  {
    //                    //      if(outputText[actualLine].Length >= lineIntro.Length)
    //                    //      {
    //                    //          if(outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Example)
    //                    //          {
    //                    //              printError = false;
    //                    //
    //                    //              ADD CUSTOM ACTION TO EXECUTE WHEN PLAYER USES THIS COMMAND
    //                    //
    //                    //          }
    //                    //      }
    //                    //  }
    //                    //
    //                    //  [...]

    //                    //----//

    //                    for (int custom_InputsIndex = 0; custom_InputsIndex < custom_Inputs.Count; custom_InputsIndex++)
    //                    {
    //                        foreach (string input_Text in custom_Inputs[custom_InputsIndex].text_Input)
    //                        {
    //                            if (outputText[actualLine].Length >= lineIntro.Length)
    //                            {
    //                                if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Text)
    //                                {
    //                                    printError = false;
    //                                    PrintCustomText(custom_InputsIndex);

    //                                    custom_Functions[custom_InputsIndex].Invoke();
    //                                }
    //                            }
    //                        }
    //                    }

    //                    //----//

    //                    foreach (string input_Help in inputs_Help)
    //                    {
    //                        if (outputText[actualLine].Length >= lineIntro.Length)
    //                        {
    //                            if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Help)
    //                            {
    //                                printError = false;
    //                                PrintHelp();
    //                            }
    //                        }
    //                    }

    //                    //----//

    //                    foreach (string input_Clear in inputs_Clear)
    //                    {
    //                        if (outputText[actualLine].Length >= lineIntro.Length)
    //                        {
    //                            if (outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Clear)
    //                            {
    //                                printError = false;
    //                                outputText = new List<string>();
    //                                outputText.Add("");

    //                                actualLine = 0;
    //                                fakeLine = -1;
    //                            }
    //                        }
    //                    }

    //                    foreach (string input_Shutdown in inputs_Shutdown)
    //                    {
    //                        if (outputText[actualLine].Length >= lineIntro.Length)
    //                        {
    //                            if (!key_UseKeyToShutDown && outputText[actualLine].Replace("" + cursor_Char, "").Substring(lineIntro.Length) == input_Shutdown)
    //                            {
    //                                printError = false;
    //                                ShutdownTerminal();
    //                            }
    //                        }
    //                    }

    //                    PrintError(printError);

    //                }
    //            }

    //            if (!logged && admin_RequestLogin)
    //            {
    //                lineIntro = "Insert password: ";
    //                fakeLine = -1;
    //            }
    //            else
    //            {
    //                fakeLine++;
    //                lineIntro = "" + fakeLine + ".  ";
    //            }

    //            AddLineToList(lineIntro);

    //        }
    //        else
    //        {
    //            if (outputText[actualLine].Contains("" + cursor_Char))
    //            {
    //                string temp = "";
    //                foreach (char letter in outputText[actualLine])
    //                {
    //                    if (letter != cursor_Char)
    //                        temp += letter;
    //                }

    //                if (outputText[actualLine].Length < text_MaxCharsInString)
    //                {
    //                    outputText[actualLine] = temp + c + cursor_Char;
    //                }
    //            }
    //            else
    //            {
    //                if (outputText[actualLine].Length < text_MaxCharsInString)
    //                {
    //                    outputText[actualLine] += c;
    //                }
    //            }
    //        }
    //    }
    //    screen.text = GenerateTextFromList(outputText);
    //}





    IEnumerator TerminalIdlingCursor()
    {
        while (terminalIsIdling)
        {
            outputText = new List<string>();
            if (!terminalStarting)
            {
                if (!cursorVisible)
                {
                    outputText.Add("" + cursor_Char);
                    cursorVisible = true;
                }
                else
                {
                    cursorVisible = false;
                }
            }

            screen.text = GenerateTextFromList(outputText);

            yield return new WaitForSeconds(cursor_BlinkingTime);
        }
    }

    private string GenerateTextFromList(List<string> lines)
    {
        actualLine = -1;

        string textToPrint = "";

        foreach (string line in lines)
        {
            actualLine++;

            textToPrint += (line + "\n");
        }

        return textToPrint;
    }

}


[System.Serializable]
public class CustomText
{
    public string[] text_Input;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileExplorer : MonoBehaviour
{
    [SerializeField]
    GameObject fileExplorerWindow;

    
    //Delete - Present ID + Decryption key
    





    public void InitFileExplorer()
    {
        fileExplorerWindow.SetActive(true);
    }

    public void DisableFileExplorer()
    {
        fileExplorerWindow.SetActive(false);
    }

}

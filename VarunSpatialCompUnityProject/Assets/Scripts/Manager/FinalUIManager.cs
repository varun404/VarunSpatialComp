using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalUIManager : MonoBehaviour
{


    [SerializeField]
    GameObject timeTravelUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DeleteTimeTravelFiles()
    {
        timeTravelUI.SetActive(false);
    }
    

}

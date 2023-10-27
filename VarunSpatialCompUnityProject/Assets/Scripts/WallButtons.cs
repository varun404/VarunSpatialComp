using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtons : MonoBehaviour
{
    [SerializeField]
    Material defaultMaterial, selectedMat;


    // Start is called before the first frame update
    void Start()
    {
        if (defaultMaterial == null)
            defaultMaterial = GetComponent<MeshRenderer>().sharedMaterial;    
    }

 

    public void SetDefaultMaterial()
    {
        GetComponent<MeshRenderer>().sharedMaterial = defaultMaterial;
    }



    public void SetSelectedMaterial()
    {
        GetComponent<MeshRenderer>().sharedMaterial = selectedMat;
    }

}

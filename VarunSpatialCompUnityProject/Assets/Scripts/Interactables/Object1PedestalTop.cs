using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1PedestalTop : MonoBehaviour
{

    [SerializeField]
    int numberToReveal = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //Top indicator
        //Enable rotation tracking
    }



    private void OnTriggerExit(Collider other)
    {
        //Top Indicator
    }


}

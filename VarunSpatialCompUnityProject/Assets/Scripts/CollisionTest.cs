using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{

    [SerializeField]
    Material triggerenterMaterial, triggerExitMaterial;

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
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().sharedMaterial = triggerenterMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().sharedMaterial = triggerExitMaterial;
        }
    }
}

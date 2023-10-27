using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{

    [SerializeField]
    Material triggerenterMaterial, triggerExitMaterial;


    [SerializeField]
    WallButtons relevantWallButton;


    [SerializeField]
    string objectTag;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(objectTag))
        {
            GetComponent<MeshRenderer>().sharedMaterial = triggerenterMaterial;
            relevantWallButton.SetSelectedMaterial();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            GetComponent<MeshRenderer>().sharedMaterial = triggerExitMaterial;
            relevantWallButton.SetDefaultMaterial();
        }
    }
}

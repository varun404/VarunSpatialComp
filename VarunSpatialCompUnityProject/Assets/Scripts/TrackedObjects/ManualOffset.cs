using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualOffset : MonoBehaviour
{

    [SerializeField]
    Transform targetTransform;



    [Header("Offsets")]

    [SerializeField]
    Vector3 positionOffset = Vector3.zero;

    [SerializeField]
    Vector3 rotationOffset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePose();
    }



    void UpdatePose()
    {
        targetTransform.localPosition = targetTransform.localPosition + positionOffset;
        targetTransform.localRotation = targetTransform.localRotation * Quaternion.Euler(rotationOffset);       
    }
}

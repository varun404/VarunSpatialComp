using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceCalculator : MonoBehaviour
{    
    public static Vector3 sourcePosition;
    
    public static Vector3 targetPosition;


    public static float CurrentDistance
    {
        get
        {
            return currentDistance;
        }

        private set { }
    }

    static float currentDistance;


    // Update is called once per frame
    void Update()
    {
        currentDistance = Mathf.Abs(Vector3.Distance(targetPosition, sourcePosition));   
    }

}

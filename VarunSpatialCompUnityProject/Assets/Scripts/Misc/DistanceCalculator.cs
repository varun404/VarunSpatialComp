using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceCalculator : MonoBehaviour
{

    [SerializeField]
    Transform sourceObject;


    [SerializeField]
    Transform targetObject;


    //[SerializeField]
    //float distanceThreshold = 1f;

    //public Action OnDistanceThreshold_Start, OnDistanceThreshold_Stay, OnDistanceThreshold_Exit;
    //public UnityEvent OnDistanceThreshold_Start_UE, OnDistanceThreshold_Stay_UE, OnDistanceThreshold_Exit_UE;


    public float CurrentDistance
    {
        get
        {
            return currentDistance;
        }

        private set { }
    }

    float currentDistance;
    //bool isEnteredDistanceThreshold = false;


    // Update is called once per frame
    void Update()
    {
        currentDistance = Mathf.Abs(Vector3.Distance(targetObject.position, sourceObject.position));

        //if(currentDistance < distanceThreshold)
        //{
        //    if(!isEnteredDistanceThreshold)
        //    {
        //        OnDistanceThreshold_Start?.Invoke();
        //        OnDistanceThreshold_Start_UE?.Invoke();
            
        //        isEnteredDistanceThreshold = true;
                
        //        Debug.Log("Entered");
        //    }

        //    OnDistanceThreshold_Stay?.Invoke();
        //    OnDistanceThreshold_Stay_UE?.Invoke();
            
        //    Debug.Log("Stay");
        //}
        //else
        //{
        //    if(isEnteredDistanceThreshold)
        //    {
        //        isEnteredDistanceThreshold = false;
                
        //        OnDistanceThreshold_Exit?.Invoke();
        //        OnDistanceThreshold_Exit_UE?.Invoke();

        //        Debug.Log("Exit");
        //    }
        //}
    }

}

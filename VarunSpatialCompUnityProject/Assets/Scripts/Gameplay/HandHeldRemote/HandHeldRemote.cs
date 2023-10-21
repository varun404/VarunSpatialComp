using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldRemote : MonoBehaviour
{
    public static HandHeldRemote handRemote;
    static Vector3 currentTargetPosition;

    void Awake()
    {
        if (handRemote == null)
            handRemote = this;
        else
            Destroy(this);
    }


    private void Update()
    {
        
    }

    public void SetPuzzleTarget(Vector3 newTargetPosition)
    {
        currentTargetPosition = newTargetPosition;
        DistanceCalculator.targetPosition = currentTargetPosition;
    }

}

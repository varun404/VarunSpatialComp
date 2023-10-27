using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandHeldDevice : MonoBehaviour
{
    [System.Serializable]
    public enum DeviceTargets
    {
        None,        
        Object1,
        Object2,
        Object3,
        Tutorial
    }

    public static DeviceTargets currentDeviceTarget { get; private set; } = DeviceTargets.None;


    [SerializeField]
    PlayerHandHeldDeviceTargets tutorialObject, object1, object2, object3;


    // Start is called before the first frame update
    void Start()
    {
        DistanceCalculator.sourcePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ChangeDeviceTarget(0);
        }
    }


    DeviceTargets tempTargetVar;
    public void ChangeDeviceTarget(int newDeviceTargetID)
    {
        tempTargetVar = (DeviceTargets)newDeviceTargetID;

        if (tempTargetVar == currentDeviceTarget)
            return;

        currentDeviceTarget = tempTargetVar;

        switch (currentDeviceTarget)
        {
            case DeviceTargets.None:
                FindObjectOfType<AudioManagerDistanceBased>().StopAudioBeepEffect();                
                break;                
            case DeviceTargets.Tutorial:
                DistanceCalculator.targetPosition = tutorialObject.targetTransform.position;
                FindObjectOfType<AudioManagerDistanceBased>().StartAudioBeepEffect();
                break;
            case DeviceTargets.Object1:
                DistanceCalculator.targetPosition = object1.targetTransform.position;
                FindObjectOfType<AudioManagerDistanceBased>().StartAudioBeepEffect();
                break;
            case DeviceTargets.Object2:
                DistanceCalculator.targetPosition = object2.targetTransform.position;
                FindObjectOfType<AudioManagerDistanceBased>().StartAudioBeepEffect();
                break;
            case DeviceTargets.Object3:
                DistanceCalculator.targetPosition = object3.targetTransform.position;
                FindObjectOfType<AudioManagerDistanceBased>().StartAudioBeepEffect();
                break;                          
        }
    }
}


[System.Serializable]
public struct PlayerHandHeldDeviceTargets
{
    public Transform targetTransform;
}

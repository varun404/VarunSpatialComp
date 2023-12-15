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
    }

    public static DeviceTargets currentDeviceTarget { get; private set; } = DeviceTargets.None;


    [SerializeField]
    PlayerHandHeldDeviceTargets object1, object2, object3;


    static PlayerHandHeldDevice currentTarget;


    [SerializeField]
    AudioManagerDistanceBased audioManagerDistanceBased;


    Vector3 currentTargetLocation;



    // Start is called before the first frame update
    void Start()
    {
        GameConstants.playerGameObject = transform.gameObject;

        TCPServer.OnReceivedUpdateFromClient += ReceivedUpdateFromClient;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            ChangeDeviceTarget(0);
        }

        DistanceCalculator.sourcePosition = transform.position;
        DistanceCalculator.targetPosition = currentTargetLocation;

    }

    void ReceivedUpdateFromClient(string message)
    {
        switch (message)
        {
            case "StartPicture":
                Debug.Log("Picture locating now");
                ChangeDeviceTarget(1);
                break;


            case "StartBook":
                Debug.Log("Book locating now");
                ChangeDeviceTarget(2);
                break;

            case "StartFormula":
                Debug.Log("Formula locating now");
                ChangeDeviceTarget(3);
                break;

            default:
                break;
        }
    }




    DeviceTargets tempTargetVar;
    public void ChangeDeviceTarget(int newDeviceTargetID)
    {
       tempTargetVar = (DeviceTargets)newDeviceTargetID;        

        currentDeviceTarget = tempTargetVar;

        switch (currentDeviceTarget)
        {
            case DeviceTargets.None:
                audioManagerDistanceBased.StopAudioBeepEffect();                
                break;      
                
            case DeviceTargets.Object1:
                DistanceCalculator.targetPosition = object1.targetTransform.position;
                currentTargetLocation = DistanceCalculator.targetPosition;
                audioManagerDistanceBased.StartAudioBeepEffect();
                Debug.Log("Device target change");
                break;
            case DeviceTargets.Object2:
                DistanceCalculator.targetPosition = object2.targetTransform.position;
                currentTargetLocation = DistanceCalculator.targetPosition;
                audioManagerDistanceBased.StartAudioBeepEffect();
                break;
            case DeviceTargets.Object3:
                DistanceCalculator.targetPosition = object3.targetTransform.position;
                audioManagerDistanceBased.StartAudioBeepEffect();
                break;                 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TargetSpot"))
        {
            ChangeDeviceTarget(0);
        }
    }
}


[System.Serializable]
public struct PlayerHandHeldDeviceTargets
{
    public Transform targetTransform;
}

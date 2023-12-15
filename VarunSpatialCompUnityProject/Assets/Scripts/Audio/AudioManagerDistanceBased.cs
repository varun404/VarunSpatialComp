using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerDistanceBased : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;


    [SerializeField]
    AnimationCurve instancesPerSecond_Distance_Ratio;


    [SerializeField]
    float defaultIntervalBetweenAudioClip;

    bool startDistanceBasedBeep = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(audioSource == null)
        {
            if (FindObjectOfType<AudioSource>() == null)
            {
                audioSource = new GameObject("RuntimeAudioSource").AddComponent<AudioSource>();
            }
            else
                audioSource = FindObjectOfType<AudioSource>();
        }
    }


    public void StartAudioBeepEffect()
    {
        startDistanceBasedBeep = true;
        Debug.Log("Started audio beep effect");
        StartCoroutine(AudioEffectBasedOnDistance());
    }


    public void StopAudioBeepEffect()
    {
        startDistanceBasedBeep = false;
        StopCoroutine(AudioEffectBasedOnDistance());
    }



    float numberOfTimesPerSecond;
    Vector3 projectedForward, directionToTarget;
    float dotProduct;
    IEnumerator AudioEffectBasedOnDistance()
    {
        Debug.Log("Starting audio coroutine");

        while (startDistanceBasedBeep)
        {
            projectedForward = Vector3.ProjectOnPlane(GameConstants.playerGameObject.transform.forward, Vector3.up);
            directionToTarget = DistanceCalculator.targetPosition - DistanceCalculator.sourcePosition;

            dotProduct = Vector3.Dot(projectedForward.normalized, directionToTarget.normalized);

            Debug.Log("dot + " + dotProduct);

            //If angle between source forward and direction to target is atleast 30 degrees
            //https://docs.unity3d.com/uploads/Main/CosineValues.png
            if (dotProduct >= 0.8f)
            {
                Debug.Log("Dist: " + DistanceCalculator.currentDistance);

                numberOfTimesPerSecond = instancesPerSecond_Distance_Ratio.Evaluate(DistanceCalculator.currentDistance);

                Debug.Log("Instances: " + numberOfTimesPerSecond);

                audioSource.PlayOneShot(audioSource.clip);
                
                Debug.Log("In View");

                yield return new WaitForSecondsRealtime(numberOfTimesPerSecond);
            }
            else
            {
                Debug.Log("Out of View");
                audioSource.PlayOneShot(audioSource.clip);
                yield return new WaitForSecondsRealtime(1f);
            }
                        
        }
        
    }


}

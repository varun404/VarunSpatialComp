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
        StartCoroutine(AudioEffectBasedOnDistance());
    }


    public void StopAudioBeepEffect()
    {
        StopCoroutine(AudioEffectBasedOnDistance());
    }



    float numberOfTimesPerSecond;
    Vector3 projectedForward, directionToTarget;
    float dotProduct;
    IEnumerator AudioEffectBasedOnDistance()
    {        

        while(true)
        {
            projectedForward = Vector3.ProjectOnPlane(GameConstants.playerGameObject.transform.forward, Vector3.up);
            directionToTarget = DistanceCalculator.targetPosition - DistanceCalculator.sourcePosition;

            dotProduct = Vector3.Dot(projectedForward.normalized, directionToTarget.normalized);

            Debug.Log(dotProduct);

            //If angle between source forward and direction to target is atleast 30 degrees
            //https://docs.unity3d.com/uploads/Main/CosineValues.png
            if (dotProduct >= 0.8f)
            {
                numberOfTimesPerSecond = instancesPerSecond_Distance_Ratio.Evaluate(DistanceCalculator.currentDistance);

                audioSource.PlayOneShot(audioSource.clip);

                yield return new WaitForSecondsRealtime(numberOfTimesPerSecond);
            }
            else
            {
                audioSource.PlayOneShot(audioSource.clip);
                yield return new WaitForSecondsRealtime(1f);
            }
                        
        }
        
    }


}

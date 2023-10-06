using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerDistanceBased : MonoBehaviour
{
    [SerializeField]
    DistanceCalculator distanceCalculator;

    [SerializeField]
    AudioSource audioSource;


    [SerializeField]
    AnimationCurve instancesPerSecond_Distance_Ratio;


    // Start is called before the first frame update
    void Start()
    {
        if (distanceCalculator == null)
            distanceCalculator = FindObjectOfType<DistanceCalculator>();

        AudioBeepEffect();
    }


    // Update is called once per frame
    void Update()
    {

    }



    void AudioBeepEffect()
    {
        StartCoroutine(AudioEffectBasedOnDistance());
    }

    float numberOfTimesPerSecond;
    IEnumerator AudioEffectBasedOnDistance()
    {        

        while(true)
        {
            numberOfTimesPerSecond = instancesPerSecond_Distance_Ratio.Evaluate(distanceCalculator.CurrentDistance);
            Debug.Log(numberOfTimesPerSecond);
            
            audioSource.PlayOneShot(audioSource.clip);
            yield return new WaitForSecondsRealtime(1f / numberOfTimesPerSecond);        
            
        }
        
    }
}

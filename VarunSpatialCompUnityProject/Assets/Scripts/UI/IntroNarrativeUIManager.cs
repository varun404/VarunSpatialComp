using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IntroNarrativeUIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text[] narrativeLinesInOrder;

    [SerializeField]
    float delayBeforeNextLine = 1f;
    
    [SerializeField]
    float fadeSpeed = 1.6f;
    
    
    

    // Start is called before the first frame update
    IEnumerable Start()
    {
        foreach (var item in narrativeLinesInOrder)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, 0f);
        }
        
        yield return StartCoroutine(StartNarrativeLinesEffect());

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }


    Color32 textColor;
    float fadeAmount;
    int linesIndex = 0;
    IEnumerator StartNarrativeLinesEffect()
    {
        while (linesIndex < narrativeLinesInOrder.Length)
        {            
            while (narrativeLinesInOrder[linesIndex].color.a < 0.98f)
            {
                textColor = narrativeLinesInOrder[linesIndex].color;
                fadeAmount += Time.deltaTime * fadeSpeed;
                narrativeLinesInOrder[linesIndex].color = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);
                yield return null;
            }

            narrativeLinesInOrder[linesIndex].color = new Color(textColor.r, textColor.g, textColor.b, 1f);
            fadeAmount = 0f;
            linesIndex++;

            if (linesIndex < narrativeLinesInOrder.Length)
                yield return new WaitForSecondsRealtime(delayBeforeNextLine);            
        } 

        Debug.Log("Ended narrartive lines effect");

        yield break;
    }



}

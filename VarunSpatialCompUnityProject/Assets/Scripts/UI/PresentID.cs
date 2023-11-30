using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentID : MonoBehaviour
{

    [SerializeField]
    TMPro.TMP_Text presentIDText;

    [SerializeField]
    KeyCode key1Debug, key2Debug;



    private void Update()
    {
        if (Input.GetKeyDown(key1Debug))
            Key1Verified();

        if (Input.GetKeyDown(key2Debug))
            Key2Verified();
    }



    public void Key1Verified()
    {
        presentIDText.text = "Key 1 of 2 verified!";
        StartCoroutine(ChangeTextAfterWait("Present Key 2 of 2", 2.5f));
    }


    public void Key2Verified()
    {
        presentIDText.text = "Key 2 of 2 verified!";
        StartCoroutine(ChangeTextAfterWait("Welcome PlaceholderScientistName!", 2.5f));
    }


    IEnumerator ChangeTextAfterWait(string newText, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        presentIDText.text = newText;
    }
}

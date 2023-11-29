using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PCPassword : MonoBehaviour
{
    [SerializeField]
    GameObject pCPasswordUI;


    [SerializeField]
    string correctPassword;

    [SerializeField]
    TMPro.TMP_InputField userPasswordInput;

    [SerializeField]
    TMPro.TMP_Text passwordHint;

    [Space(10)]

    public static Action OnUserAuthenticationSuccesful, OnUserAuthenticationFailed;

    [Space(20)]

    public UnityEvent OnUserAuthenticationSuccesful_UE, OnUserAuthenticationFailed_UE;

    public void AuthenticatePlayer()
    {
        if (IsPasswordValid())
        {
            OnUserAuthenticationSuccesful?.Invoke();
            OnUserAuthenticationSuccesful_UE?.Invoke();
        }
        else
        {
            OnUserAuthenticationFailed?.Invoke();
            OnUserAuthenticationFailed_UE?.Invoke();
        }

    }


    bool IsPasswordValid()
    {

        if (String.Equals(userPasswordInput.text.ToLower(), correctPassword.ToLower()))
            return true;

        return false;
    }


    public void ShowHint()
    {
        StartCoroutine(ShowHintForSeconds());
    }

    IEnumerator ShowHintForSeconds()
    {
        passwordHint.gameObject.SetActive(true);

        yield return new WaitForSeconds(7f);

        passwordHint.gameObject.SetActive(false);
    }


}

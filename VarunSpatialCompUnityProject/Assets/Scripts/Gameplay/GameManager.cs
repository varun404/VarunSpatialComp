using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    public static Action<GameConstants.GameState> GameStateChanged;


    [SerializeField]
    Transform dummyTarget;

    // Start is called before the first frame update
    void Start()
    {
        GameConstants.playerGameObject = player;
    }



    // Update is called once per frame
    void Update()
    {
        DistanceCalculator.sourcePosition = player.transform.position;
        DistanceCalculator.targetPosition = dummyTarget.position;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManagerDistanceBased>().StartAudioBeepEffect();
        }
    }



    public void SetGameState(GameConstants.GameState newGameState)
    {
        if (newGameState == GameConstants.GetCurrentGameState())
            return;

        GameConstants.SetGameState(newGameState);

        //Set New Game State
        GameStateChanged?.Invoke(newGameState);
    }
}

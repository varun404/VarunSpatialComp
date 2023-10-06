using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action<GameConstants.GameState> GameStateChanged;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

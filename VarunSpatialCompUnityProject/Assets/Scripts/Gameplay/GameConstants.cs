using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public enum GameState
    {
        Intro,
        Lock1,
        Lock2,
        Lock3,
        End
    }
    static GameState currentGameState = GameState.Intro;

    public static GameState GetCurrentGameState()
    {
        return currentGameState;
    }


    public static void SetGameState(GameState _gameState)
    {
        currentGameState = _gameState;
    }


}

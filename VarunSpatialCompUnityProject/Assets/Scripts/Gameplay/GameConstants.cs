using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public static GameObject playerGameObject;


    public enum GameState
    {
        Intro,
        Puzzle1Solved,
        Puzzle2Solved,        
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

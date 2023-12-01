using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameStateChanged += SetPuzzle;
    }


    private void OnDisable()
    {
        GameManager.GameStateChanged -= SetPuzzle;
    }


    void SetPuzzle(GameConstants.GameState puzzle)
    {
        switch (puzzle)
        {           
            case GameConstants.GameState.Puzzle1Solved:
                FindObjectOfType<Puzzle1Year>().Start();
                break;

            case GameConstants.GameState.Puzzle2Solved:                
                break;                       
        }
    }
}

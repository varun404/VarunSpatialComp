using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleAbstract : MonoBehaviour
{
    //War crime sorry
    //public abstract Transform puzzleTransform { get; }

    public abstract void OnPuzzleStart();
    public abstract void OnPuzzleFinished();


    public abstract void Start();
}

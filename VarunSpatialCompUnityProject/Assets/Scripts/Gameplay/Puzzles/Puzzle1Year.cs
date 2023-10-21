using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Year : PuzzleAbstract
{

    [SerializeField]
    Transform puzzleTransformInSpace;

    //public override Transform puzzleTransform
    //{
    //    get
    //    {
    //        return puzzleTransformInSpace;
    //    }
    //}

    public override void OnPuzzleFinished()
    {
        
    }

    public override void OnPuzzleStart()
    {
        HandHeldRemote.handRemote.SetPuzzleTarget(puzzleTransformInSpace.position);
    }

    public override void Start()
    {
        OnPuzzleStart();
    }

}

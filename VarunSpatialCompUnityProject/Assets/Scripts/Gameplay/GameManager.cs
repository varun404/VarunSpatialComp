using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    public static Action<GameConstants.GameState> GameStateChanged;



    // Start is called before the first frame update
    void Start()
    {
        GameConstants.playerGameObject = player;
    }



    // Update is called once per frame
    void Update()
    {        
    }

}

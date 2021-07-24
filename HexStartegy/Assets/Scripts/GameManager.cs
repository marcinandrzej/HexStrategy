using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Lobby,
    InGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab = null;
    
    #region PUBLIC VARIABLES
    
    [Header("Game Status")] // Easy info in what state of the game we are
    public readonly GameState GameState;
    
    #endregion
    
    
    #region GAME METHODS

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }
    
    
}

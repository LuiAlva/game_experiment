using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    PC_StateMoving levelSetup;
    PlayerManager playerManager;
    GameObject Managers;

    void Awake()
    {
        instance = this;
        Managers = GameObject.Find("Systems");
        playerManager = Managers.GetComponent<PlayerManager>();
    }
    
    //void Start()
    //{
    //    UpdateGameState(GameState.MainMenu);
    //}

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameState.PlayerSetup:
                HandlePlayerSetup();
                break;
            case GameState.Level_1:
                SceneManager.LoadScene("TestScene");
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, $"Game State {newState} is not in GameManager.");

        }
        OnGameStateChanged?.Invoke(newState);
    }

    void HandlePlayerSetup()
    {
        //playerManager.ActivatePlayer();
        UpdateGameState(GameState.MainMenu);
    }

    public enum GameState
    {
        MainMenu,
        PlayerSetup,
        Level_1,
        GameOver
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Systems").GetComponent<GameManager>();
    }
    public void NewGame()
    {
        gameManager.UpdateGameState(GameManager.GameState.Level_1);
    }

    public void OpenOptionsMenu()
    {

    }

    public void ExitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

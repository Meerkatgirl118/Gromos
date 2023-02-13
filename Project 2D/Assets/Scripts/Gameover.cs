using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    GameOverPrep gameOverPrep;
    private void Start()
    {
        gameOverPrep = FindObjectOfType<GameOverPrep>();
    }
    public void RestartLevel()
    {
        if (gameOverPrep.currentScene != null)
        {
            SceneManager.LoadScene(gameOverPrep.currentScene);
        }
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPrep : MonoBehaviour
{
    public string currentScene;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void GameOverTriggered()
    {
        currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Gameover screen");
    }
}

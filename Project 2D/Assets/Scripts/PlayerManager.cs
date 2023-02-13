using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameOverPrep gameOverPrep;

    public int starsCollected = 0;
    public int playerHealth = 5;

    void Start()
    {
        gameOverPrep = FindObjectOfType<GameOverPrep>();
    }
    void Update()
    {
        if (playerHealth <= 0)
        {
            gameOverPrep.GameOverTriggered();
        }
    }
}

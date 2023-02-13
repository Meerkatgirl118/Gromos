using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundGameover : MonoBehaviour
{
    PlayerManager playerManager;
    GameOverPrep gameOverPrep;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        gameOverPrep = FindObjectOfType<GameOverPrep>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverPrep.GameOverTriggered();
        }
    }
}

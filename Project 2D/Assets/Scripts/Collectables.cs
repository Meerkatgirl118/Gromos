using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] bool thisCollected = false;
    PlayerManager playerManager;
    
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!thisCollected)
            {
                thisCollected = true;
                playerManager.starsCollected++;
                Destroy(gameObject);
            }
        }
    }
}

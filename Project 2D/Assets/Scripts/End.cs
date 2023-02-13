using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class End : MonoBehaviour
{
    StoreStarCount storeStarCount;
    PlayerManager playerManager;
    public bool levelCompleteTrigger = false;
    private void Start()
    {
        storeStarCount = FindObjectOfType<StoreStarCount>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            storeStarCount.totalStars += playerManager.starsCollected;
            levelCompleteTrigger = true;
        }
    }
}

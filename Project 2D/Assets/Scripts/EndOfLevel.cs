using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndOfLevel : MonoBehaviour
{
    StoreStarCount storeStarCount;
    PlayerManager playerManager;

    [SerializeField] TMP_Text currentStarsText;
    [SerializeField] TMP_Text totalStarsText;

    int currentScene;
    void Start()
    {
        storeStarCount = FindObjectOfType<StoreStarCount>();
        playerManager = FindObjectOfType<PlayerManager>();

        currentStarsText.text = playerManager.starsCollected.ToString();
        totalStarsText.text = storeStarCount.totalStars.ToString();
    }

    public void NextLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}

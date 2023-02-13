using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text starText;
    public GameObject punchUI;
    PlayerManager playerManager;

    [SerializeField] GameObject levelEndUI;
    End end;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if (FindObjectOfType<End>() != null)
        {
            end = FindObjectOfType<End>();
        }
    }

    void Update()
    {
        healthText.text = playerManager.playerHealth.ToString();
        starText.text = playerManager.starsCollected.ToString();
        if (FindObjectOfType<End>() != null)
        {
            if (end.levelCompleteTrigger)
            {
                levelEndUI.SetActive(true);
            }
        }
    }
}

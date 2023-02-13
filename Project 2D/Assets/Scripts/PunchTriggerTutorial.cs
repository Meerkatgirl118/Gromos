using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTriggerTutorial : MonoBehaviour
{
    UIManager uIManager;
    GameObject punchUI;

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        punchUI = uIManager.punchUI;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            punchUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            punchUI.SetActive(false);
        }
    }
}

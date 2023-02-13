using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    StoreStarCount storeStarCount;
    [SerializeField] Image cutsceneImage1;
    [SerializeField] Image cutsceneImage2;
    [SerializeField] GameObject titleScreen;
    [SerializeField] TMP_Text cutsceneText;

    [SerializeField] GameObject totalStarsUI;
    [SerializeField] TMP_Text totalStarsText;

    [SerializeField] int cutsceneTextDisplayed;
    [SerializeField] bool switchingText = false;

    private void Start()
    {
        storeStarCount = FindObjectOfType<StoreStarCount>();
    }
    void Update()
    {
        CheckForClickInput();
        Text();
    }

    void CheckForClickInput()
    {
        if (!switchingText)
        {
            if (Input.anyKey || Input.GetMouseButton(0))
            {
                switchingText = true;
                cutsceneTextDisplayed++;
                StartCoroutine(Wait());
            }
        }
    }

    void Text()
    {
        if (cutsceneTextDisplayed == 0) { cutsceneText.text = "This is it! It's the necklace."; cutsceneImage1.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 1) { cutsceneText.text = "I'll have to keep this safe from now on."; }
        if (cutsceneTextDisplayed == 2) { cutsceneText.text = "I'm truly lucky to have found it here."; }
        if (cutsceneTextDisplayed == 3) { cutsceneText.text = "Still, I wonder why those aliens took it."; }
        if (cutsceneTextDisplayed == 4) { cutsceneText.text = "Oh well, not everything needs to be answered."; }
        if (cutsceneTextDisplayed == 5) { cutsceneText.text = ""; cutsceneImage1.gameObject.SetActive(false); }
        if (cutsceneTextDisplayed == 6) { cutsceneImage2.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 7) { cutsceneImage2.gameObject.SetActive(false); }
        if (cutsceneTextDisplayed == 8) {  totalStarsText.text = storeStarCount.totalStars.ToString() ; totalStarsUI.SetActive(true); }
        if (cutsceneTextDisplayed == 9) { titleScreen.SetActive(true); totalStarsUI.SetActive(false); }
        if (cutsceneTextDisplayed == 10) { SceneManager.LoadScene("Title screen"); }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        switchingText = false;
    }
}

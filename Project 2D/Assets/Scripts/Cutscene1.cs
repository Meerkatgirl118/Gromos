using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour
{
    [SerializeField] Image cutsceneImage1;
    [SerializeField] Image cutsceneImage2;
    [SerializeField] Image cutsceneImage3;
    [SerializeField] Image cutsceneImage4;
    [SerializeField] Image cutsceneImage5;
    [SerializeField] Image cutsceneImage6;
    [SerializeField] GameObject titleScreen;
    [SerializeField] TMP_Text cutsceneText;

    [SerializeField] int cutsceneTextDisplayed;
    [SerializeField] bool switchingText = false;

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
        if (cutsceneTextDisplayed == 0) { cutsceneText.text = "My son..."; }
        if (cutsceneTextDisplayed == 1) { cutsceneText.text = "I will not be in this world for much longer."; }
        if (cutsceneTextDisplayed == 2) { cutsceneText.text = "So I want you to have this."; }
        if (cutsceneTextDisplayed == 3) { cutsceneText.text = "This necklace has been passed down through generations."; }
        if (cutsceneTextDisplayed == 4) { cutsceneText.text = "Do you understand, my son?"; }
        if (cutsceneTextDisplayed == 5) { cutsceneImage1.gameObject.SetActive(false); cutsceneText.text = "..."; }
        if (cutsceneTextDisplayed == 6) { cutsceneImage2.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 7) { cutsceneText.text = "Mother..."; }
        if (cutsceneTextDisplayed == 8) { cutsceneImage2.gameObject.SetActive(false); cutsceneImage3.gameObject.SetActive(true); cutsceneText.text = "!!";  }
        if (cutsceneTextDisplayed == 9) { cutsceneImage3.gameObject.SetActive(false); cutsceneImage4.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 10) { cutsceneText.text = "..."; }
        if (cutsceneTextDisplayed == 11) { cutsceneText.text = "What the..."; }
        if (cutsceneTextDisplayed == 12) { cutsceneText.text = "..."; cutsceneImage4.gameObject.SetActive(false); cutsceneImage5.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 13) { cutsceneText.text = "How could this happen?"; }
        if (cutsceneTextDisplayed == 14) { cutsceneImage5.gameObject.SetActive(false); }
        if (cutsceneTextDisplayed == 15) { cutsceneText.text = "Don't worry, mother. I'll get it back."; }
        if (cutsceneTextDisplayed == 16) { cutsceneImage6.gameObject.SetActive(true); }
        if (cutsceneTextDisplayed == 17) { cutsceneText.text = "I think it's time to leave."; }
        if (cutsceneTextDisplayed == 18) { titleScreen.SetActive(true); }
        if (cutsceneTextDisplayed == 19) { SceneManager.LoadScene("Part1 - the entrance"); }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        switchingText = false;
    }
}

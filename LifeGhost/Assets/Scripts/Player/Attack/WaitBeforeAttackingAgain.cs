using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Summary: This is responsible for adding a wait time before the player can click the skill button again

public class WaitBeforeAttackingAgain : MonoBehaviour {

    [SerializeField] private int waitTime;
    private int fadeTime;

    private TextMeshProUGUI waitText;
    private Image fadeImg;

    private bool canFade;

    private GameObject waitBeforeAttackingPanel;

    private void Awake() {
        waitBeforeAttackingPanel = transform.GetChild(0).gameObject;

        waitText = waitBeforeAttackingPanel.GetComponentInChildren<TextMeshProUGUI>();
        waitText.text = waitTime.ToString();

        fadeImg = waitBeforeAttackingPanel.GetComponent<Image>();
        fadeTime = waitTime;

        waitBeforeAttackingPanel.SetActive(false);                            //To be off at start

    }

    private void Update() {
        FadeOut();
    }

    public void ActivateFadeOut() {
        waitBeforeAttackingPanel.SetActive(true);
        waitText.text = waitTime.ToString();

        //Resetting Color
        Color temp = fadeImg.color;
        temp.a = 1f;
        fadeImg.color = temp;

        StartCoroutine(CountDown());

    }

    private void FadeOut() {
        if (canFade) {
            Color temp = fadeImg.color;
            temp.a -= (Time.deltaTime / fadeTime) / 2f;
            fadeImg.color = temp;
        }

    }

    IEnumerator CountDown() {
        canFade = true;
        yield return new WaitForSeconds(1);
        waitTime -= 1;

        if (waitTime != -1) {
            waitText.text = waitTime.ToString();
            StartCoroutine(CountDown());

        } else {
            waitTime = fadeTime;
            waitBeforeAttackingPanel.SetActive(false);

        }
    }











































}//Class

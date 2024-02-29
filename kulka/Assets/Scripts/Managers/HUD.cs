using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] CanvasGroup gameOverView;
    [SerializeField] CanvasGroup currentScoreView;
    [SerializeField] CanvasGroup curtain;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI currentScore;
    public static HUD thisInstance;

    private void Awake()
    {
        thisInstance = this;
    }
    IEnumerator SpellText(TextMeshProUGUI textHolder, string text, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < text.Length; i++)
        {
            textHolder.text = text.Substring(0, i + 1);
            yield return new WaitForSeconds(.1f);
        }
    }
    IEnumerator ShowGroup(CanvasGroup group, float time, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        float startingTime = Time.time;
        while(group.alpha < 1)
        {
            float interpolation = (Time.time - startingTime) / time;
            group.alpha = Mathf.Lerp(0, 1, interpolation);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator HideGroup(CanvasGroup group, float time, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        float startingTime = Time.time;
        while (group.alpha > 0)
        {
            float interpolation = (Time.time - startingTime) / time;
            group.alpha = Mathf.Lerp(1, 0, interpolation);
            yield return new WaitForEndOfFrame();
        }
    }
    public void ShowGameOverScore(int score, int highScore)
    {
        StartCoroutine(ShowGroup(gameOverView, 1));
        string finalText = "SCORE: " + score.ToString() + "   " + "BEST: " + highScore.ToString();
        StartCoroutine(SpellText(scoreText, finalText, 1));
    }

    public void SetGameCurrentScore(int value)
    {
        currentScore.text = value.ToString();
    }
    public void ToggleGameCurrentScoreVisibility(bool visible)
    {
        if (visible)
            StartCoroutine(ShowGroup(currentScoreView, 1, .1f));
        else
            StartCoroutine(HideGroup(currentScoreView, 1, .1f));
    }
    public void ToggleCurbain(bool visible)
    {
        if (visible)
            StartCoroutine(ShowGroup(curtain, 1));
        else
            StartCoroutine(HideGroup(curtain, 1));
    }
}

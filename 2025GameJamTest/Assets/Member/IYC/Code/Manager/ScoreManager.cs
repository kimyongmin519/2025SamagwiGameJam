using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Member.SYW._01_Scripts.Manager;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        SoundManager.Instance.Play(BGMSoundType.GAMEBGM, 1f);
        UpdateScoreUI();
        StartCoroutine(ScoreCoroutine());
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        UpdateScoreUI();
        Debug.Log($"Score: {score}");
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"점수: {score}점";
        }
    }

    private IEnumerator ScoreCoroutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);
            AddScore(5);
        }
    }
    
    public int GetScore()
    {
        return score;
    }
}
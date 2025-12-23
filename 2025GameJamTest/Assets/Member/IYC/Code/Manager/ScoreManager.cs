using System;
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
        UpdateScoreUI();
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
            scoreText.text = $"점수: {score}";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            score += 50;
            UpdateScoreUI();
        }
    }

    public int GetScore()
    {
        return score;
    }
}
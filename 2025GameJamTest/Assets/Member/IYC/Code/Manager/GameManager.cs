using System;
using UnityEngine;
using Member.KYM.Code.Players;
using Member.SYW._01_Scripts.Manager;
using Member.SYW._01_Scripts.UI;

public class GameManager : MonoSingleton<GameManager>
{
    private GameOverUI _gameOverUI;
    private GameWinUI _gameWinUI;
    
    protected override void Awake()
    {
        base.Awake();
        _gameOverUI = GameOverUI.Instance;
        _gameWinUI = GameWinUI.Instance;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        _gameOverUI.gameObject.SetActive(true);
        TimeManager.Instance?.TimeStop();
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        _gameWinUI.gameObject.SetActive(true);
        TimeManager.Instance?.TimeStop();
    }
}
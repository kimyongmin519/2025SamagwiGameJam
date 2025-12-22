using System;
using UnityEngine;
using Member.KYM.Code.Players;
using Member.SYW._01_Scripts.Manager;

public class GameManager : MonoSingleton<GameManager>
{
    public Action OnGameOver;
    public Action OnVictory;
    
    protected override void Awake()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        OnGameOver?.Invoke();
        TimeManager.Instance?.TimeStop();
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        OnVictory?.Invoke();
        TimeManager.Instance?.TimeStop();
    }
}
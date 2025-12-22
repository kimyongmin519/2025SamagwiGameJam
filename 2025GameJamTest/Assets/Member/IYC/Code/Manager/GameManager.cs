using System;
using UnityEngine;
using Member.KYM.Code.Players;
using Member.SYW._01_Scripts.Manager;

public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        TimeManager.Instance?.TimeStop();
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        TimeManager.Instance?.TimeStop();
    }
}
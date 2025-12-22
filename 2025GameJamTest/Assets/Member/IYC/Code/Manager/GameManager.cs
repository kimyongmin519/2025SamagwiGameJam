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
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        Time.timeScale = 0f;
    }
}
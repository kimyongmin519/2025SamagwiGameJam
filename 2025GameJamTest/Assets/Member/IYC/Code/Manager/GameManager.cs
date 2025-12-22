using System;
using UnityEngine;
using Member.KYM.Code.Players;
using Member.SYW._01_Scripts.Manager;
using Member.SYW._01_Scripts.UI;

public class GameManager : MonoSingleton<GameManager>
{
    protected override void Awake()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverUI.Instance.gameObject.SetActive(true);
        TimeManager.Instance?.TimeStop();
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        GameWinUI.Instance.gameObject.SetActive(true);
        TimeManager.Instance?.TimeStop();
    }
}
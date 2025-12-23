using UnityEngine;
using Member.SYW._01_Scripts.Manager;
using Member.SYW._01_Scripts.UI;

public class GameManager : MonoSingleton<GameManager>
{
    private GameEndUI _gameEndUI;
    
    protected override void Awake()
    {
        base.Awake();
        _gameEndUI = GameEndUI.Instance;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        _gameEndUI.Show();
        TimeManager.Instance?.TimeStop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            GameOver();
        if (Input.GetKeyDown(KeyCode.V))
            Victory();
    }

    public void Victory() // 폐?기
    {
        Debug.Log("Victory!");
        _gameEndUI.Show();
        TimeManager.Instance?.TimeStop();
    }
}
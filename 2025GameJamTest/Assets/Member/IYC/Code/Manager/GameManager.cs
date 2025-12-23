using UnityEngine;
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
        _gameOverUI.Show();
        TimeManager.Instance?.TimeStop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            GameOver();
        if (Input.GetKeyDown(KeyCode.V))
            Victory();
    }

    public void Victory()
    {
        Debug.Log("Victory!");
        _gameWinUI.Show();
        TimeManager.Instance?.TimeStop();
    }
}
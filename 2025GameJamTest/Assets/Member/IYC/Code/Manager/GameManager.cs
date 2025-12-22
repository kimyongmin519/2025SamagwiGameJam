using System;
using UnityEngine;
using Member.KYM.Code.Players;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player player;
    public PlayerInputSO playerInput;

    public float baseScrollSpeed = 5f;
    public float currentScrollSpeed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
        }
    }

    private void Update()
    {
        UpdateScrollSpeed();
    }

    public void UpdateScrollSpeed()
    {
        if (playerInput == null) return;

        /*if (playerInput.MoveDir > 0)
        {
            currentScrollSpeed = baseScrollSpeed + 3f;
        }
        else if (playerInput.MoveDir < 0)
        {
            currentScrollSpeed = baseScrollSpeed - 2f;
        }*/
        else
        {
            currentScrollSpeed = baseScrollSpeed;
        }

        currentScrollSpeed = Mathf.Max(currentScrollSpeed, 1f);
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
using System;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class GameOverUI : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
        }

        private void OnEnable()
        {
            //_gameManager.OnGameOver +=
        }

        private void OnDisable()
        {
            //_gameManager.OnGameOver -=
        }
    }
}
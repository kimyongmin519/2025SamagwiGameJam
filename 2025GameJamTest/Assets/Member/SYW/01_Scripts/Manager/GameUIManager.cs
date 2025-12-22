using System;
using Member.SYW._01_Scripts.UI;
using UnityEngine;

namespace Member.SYW._01_Scripts.Manager
{
    public class GameUIManager : MonoBehaviour
    {
        private InGameUIHome _inGameUIHome;
        private bool _panelOpen = false;

        public Action OnEscOpen;
        public Action OnEscClose;
        
        private void Awake()
        {
            _inGameUIHome = InGameUIHome.Instance;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                HandleEsc();
        }

        private void HandleEsc()
        {
            if (!_panelOpen)
            {
                OnEscOpen?.Invoke();
                Time.timeScale = 0;
                _panelOpen = true;
            }
            else if (_panelOpen)
            {
                OnEscClose?.Invoke();
                Time.timeScale = 1;
                _panelOpen = false;
            }
        }
    }
}
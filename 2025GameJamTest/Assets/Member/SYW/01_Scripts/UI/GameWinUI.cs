using System;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class GameWinUI : MonoSingleton<GameWinUI>
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
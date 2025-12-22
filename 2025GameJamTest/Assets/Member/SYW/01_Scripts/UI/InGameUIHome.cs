using System;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class InGameUIHome : MonoSingleton<InGameUIHome>
    {
        [SerializeField] private GameUIManager gameUIManager;

        private void OnEnable()
        {
            //gameUIManager.OnEscOpen += ;
            //gameUIManager.OnEscClose += ;
        }
        
        
        
        private void OnDisable()
        {
            //gameUIManager.OnEscOpen -= ;
            //gameUIManager.OnEscClose -= ;
        }
    }
}
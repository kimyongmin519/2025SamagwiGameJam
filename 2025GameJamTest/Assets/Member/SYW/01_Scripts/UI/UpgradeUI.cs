using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private Image gunVisual;
        [SerializeField] private Image panel1;
        [SerializeField] private Image panel2;
        [SerializeField] private Image panel3;
        [SerializeField] private Image panel4;
        
        public void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Choose()
        {
            // 여기다가 버프 넘기기
            StartCoroutine(ChooseCoroutine());
        }
        
        private void ChooseComplete()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

        private IEnumerator ChooseCoroutine()
        {
            yield return null;
            ChooseComplete();
        }
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class TitleUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI creditText;
        [SerializeField] private RectTransform originTransform;
        private bool _creditIsOpen = false;

        private void Start()
        {
            titleText.transform.position = originTransform.transform.position;
            creditText.gameObject.SetActive(false);
        }

        public void EditCredit()
        {
            if (!_creditIsOpen)
            {
                creditText.gameObject.SetActive(true);
                _creditIsOpen = true;
            }
            else if (_creditIsOpen)
            {
                creditText.gameObject.SetActive(false);
                _creditIsOpen = false;
            }
        }

        public void GameStart()
        {
            SceneManager.LoadScene("Develop");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
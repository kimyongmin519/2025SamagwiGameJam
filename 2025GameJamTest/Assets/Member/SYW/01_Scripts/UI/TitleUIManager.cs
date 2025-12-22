using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.UI
{
    public class TitleUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditText;
        [SerializeField] private RectTransform originTransform;
        private TitleESCPanel _titleEscPanel;
        private bool _creditIsOpen = false;

        private void Awake()
        {
            _titleEscPanel = TitleESCPanel.Instance;
        }

        private void Start()
        {
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

        public void EscPanelOpen()
        {
            _titleEscPanel.gameObject.SetActive(true);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
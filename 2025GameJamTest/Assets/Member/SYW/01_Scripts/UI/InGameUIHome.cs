using DG.Tweening;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Member.SYW._01_Scripts.UI
{
    public class InGameUIHome : MonoSingleton<InGameUIHome>
    {
        [SerializeField] private GameUIManager gameUIManager;
        private RectTransform _rectTransform;
        private EditPanel _editPanel;
        private float _originTransform;

        protected override void Awake()
        {
            base.Awake();
            _editPanel = EditPanel.Instance;
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _originTransform = _rectTransform.localPosition.x;
        }

        private void OnEnable()
        {
            gameUIManager.OnEscOpen += AppearanceUI;
            gameUIManager.OnEscClose += UnAppearanceUI;
        }

        private void AppearanceUI()
        {
            // -1200 , -725
            _rectTransform.DOLocalMove(new Vector3(-725, 0), 1);
        }

        private void UnAppearanceUI()
        {
            _rectTransform.DOLocalMove(new Vector3(_originTransform, 0), 1);
        }

        public void EditPanelOpen()
        {
            _editPanel.gameObject.SetActive(true);
        }

        public void GoTitle()
        {
            SceneManager.LoadScene("Title");
        }

        public void Restart()
        {
            UnAppearanceUI();
        } 
        
        private void OnDisable()
        {
            gameUIManager.OnEscOpen -= AppearanceUI;
            gameUIManager.OnEscClose -= UnAppearanceUI;
        }
    }
}
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Member.SYW._01_Scripts.Events
{
    public class UIHoverEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private RectTransform _rectTransform;
        [SerializeField] private float hoverWidth;
        [SerializeField] private float duration;

        private float _originWidth;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            _originWidth = _rectTransform.sizeDelta.x;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                    new Vector2(hoverWidth, _rectTransform.sizeDelta.y), duration)
                .SetEase(Ease.Flash);
            Debug.Log("엉");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                new Vector2(_originWidth, _rectTransform.sizeDelta.y), duration)
                .SetEase(Ease.Flash);
            Debug.Log("잉");
        }

        private void OnDisable()
        {
            _rectTransform.DOKill();
        }
    }
}

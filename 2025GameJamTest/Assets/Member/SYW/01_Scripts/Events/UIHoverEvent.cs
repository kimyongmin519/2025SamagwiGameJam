using System;
using Member.KYM.Code.Bus;
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
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            
        }
    }
}

using System;
using DG.Tweening;
using Member.KYM.Code.Weapon;
using UnityEditorInternal;
using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class Hand : MonoBehaviour
    {
        private Vector2 _mousePos;
        private Gun _gun;
        private float _defaultY;

        private void Awake()
        {
            _gun = GetComponentInChildren<Gun>();
            _defaultY = transform.localPosition.y;
        }

        private void Update()
        {
            _gun.SetMousePos(_mousePos);

            Vector2 bonusPos = (_mousePos - (Vector2)transform.position) / 100f;

            transform.localPosition = new Vector2(0,_defaultY) + bonusPos;
        }

        public void SetMousePos(Vector2 dir)
        {
            _mousePos = dir;
        }
    }
}

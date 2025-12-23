using System;
using DG.Tweening;
using Member.KYM.Code.Weapon;
using UnityEditorInternal;
using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class Hand : MonoBehaviour
    {
        public Gun Gun { get; private set; }
        private Vector2 _mousePos;

        private void Awake()
        {
            Gun = GetComponentInChildren<Gun>();
        }

        public void SetMousePos(Vector2 dir)
        {
            _mousePos = dir;
        }
    }
}

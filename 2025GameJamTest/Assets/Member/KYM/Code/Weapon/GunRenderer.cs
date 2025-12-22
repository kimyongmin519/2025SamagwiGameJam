using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code.Weapon
{
    public class GunRenderer : MonoBehaviour
    {
        private Transform _trm;
        private Animator _animator;

        public void Initialize(Transform trm)
        {
            _trm = trm;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                _animator.SetTrigger("Reload");
            }
        }

        public void FlipControl(float xDir)
        {
            float targetYScale = xDir > 0 ? 1 : -1;
            _trm.transform.localScale = new Vector3(_trm.transform.localScale.x, targetYScale
                ,_trm.transform.localScale.z);
        }
    }
}

using System;
using System.Collections;
using UnityEngine;

namespace Member.KYM.Code
{
    public class TutoAdd : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Pang()
        {
            _rb.AddForceX(-100, ForceMode2D.Impulse);
        }

        private IEnumerator PangCor()
        {
            for (int i = 0; i < 500; i++)
            {
                _rb.linearVelocityX = -25;
                yield return null;
            }
        }
    }
}

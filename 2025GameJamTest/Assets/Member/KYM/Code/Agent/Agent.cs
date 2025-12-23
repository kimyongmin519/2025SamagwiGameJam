using System;
using System.Collections;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public abstract class Agent : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public HealthSystem HealthSystem { get; protected set; }

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            HealthSystem = GetComponent<HealthSystem>();
        }
    }
}
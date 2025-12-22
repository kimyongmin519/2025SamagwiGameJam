using System;
using Member.KYM.Code.Interface;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public class HealthSystem : MonoBehaviour, IAgentComponent
    {
        public float MaxHealth { get; private set; }

        [SerializeField] private float health;

        [SerializeField] private bool isInvincible = false;
        
        private Agent _agent;

        public Action OnDead; 
        
        public float Health
        {
            get => health;
            set
            {
                float before = health;

                if (!isInvincible)
                    health = Mathf.Clamp(value, 0, MaxHealth);
            }
        }
        
        public void GetDamage(float damage)
        {
            print("������ ��");

            Health -= damage;
            
            if (Health <= 0)
            {
                OnDead?.Invoke();
            }
        }
        
        public void SetHealth(float _health)
        {
            MaxHealth = _health;
            health = MaxHealth;
        }
        
        public void Initialize(Agent agent)
        {
            _agent = agent;
        }
    }
}
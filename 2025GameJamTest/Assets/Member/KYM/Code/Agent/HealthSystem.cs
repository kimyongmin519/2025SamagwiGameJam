using System;
using Member.KYM.Code.Interface;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public class HealthSystem : MonoBehaviour, IAgentComponent
    {
        public double MaxHealth { get; private set; }

        [SerializeField] private double health;

        [SerializeField] private bool isInvincible = false;
        
        private Agent _agent;

        public Action OnDead;
        public Action OnDamaged;
        
        public double Health
        {
            get => health;
            set
            {
                if (!isInvincible)
                {
                    health = Math.Clamp(value, 0, MaxHealth);
                    OnDamaged?.Invoke();
                }
            }
        }
        
        public void GetDamage(float damage)
        {
            Health -= damage;
            
            if (Health <= 0)
            {
                OnDead?.Invoke();
            }
        }
        
        public void SetHealth(double _health)
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
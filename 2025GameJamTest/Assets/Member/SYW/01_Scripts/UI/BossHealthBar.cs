using Member.KYM.Code.Agent;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class BossHealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem healthSystem;
        private Slider _hpBar;

        private void Awake()
        {
            _hpBar = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            healthSystem.OnDead += BossDieBar;
        }

        private void Start()
        {
            _hpBar.value = healthSystem.Health;
            _hpBar.maxValue = healthSystem.MaxHealth;
        }

        private void Update()
        {
            _hpBar.value = healthSystem.Health;
            _hpBar.maxValue = healthSystem.MaxHealth;
        }

        private void BossDieBar()
        {
            
        }
        
        private void OnDisable()
        {
            healthSystem.OnDead -= BossDieBar;
        }
    }
}
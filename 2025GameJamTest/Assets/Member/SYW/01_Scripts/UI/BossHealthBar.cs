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

        private void Start()
        {
            _hpBar.value = healthSystem.Health;
            _hpBar.maxValue = healthSystem.MaxHealth;
        }

        private void Update()
        {
            _hpBar.value = healthSystem.Health;
            _hpBar.maxValue = healthSystem.MaxHealth;
            
            if (Input.GetKeyDown(KeyCode.K))
                healthSystem.GetDamage(5);
        }
    }
}
using Member.KYM.Code.Agent;
using UnityEngine;

public class ElectronicDisplayBoard : MonoBehaviour
{
    private Santa _santa;
    private HealthSystem healthSystem;

    private float currentHealth = 1;
    private float _stunCoolDown = 3f;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        _santa = FindAnyObjectByType<Santa>();
        healthSystem.SetHealth(currentHealth);
    }

    private void Update()
    {
        if(healthSystem.Health <= 0)
        {
            _santa.Stun(_stunCoolDown);
        }
    }
}

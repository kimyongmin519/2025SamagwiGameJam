using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HealthManager instance;
    public HealthManager Instance => instance;

    public float santaMaxHealth = 100;
    public float _santaCurrentHealth { get; private set; }

    public float damage = 100;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        santaMaxHealth = _santaCurrentHealth;

    }
    
    public void OnDamage()
    {
        _santaCurrentHealth -= IDamageable(damage);
    }

    public float IDamageable(float damage)
    {
        return damage;
    }
}

using Member.KYM.Code.Agent;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;

    [SerializeField] private float targetDistance = 10f;
    [SerializeField] private float baseChaseSpeed = 3f;
    [SerializeField] private float maxChaseSpeed = 6f;
    [SerializeField] private float catchDistance = 10f;

    private GameManager gameManager;

    private void Awake()
    {
        if (healthSystem == null)
            healthSystem = GetComponent<HealthSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gimic"))
        {
            Gimic gimic = collision.gameObject.GetComponent<Gimic>(); gimic.gimicData.Stun = true;
            if (gimic != null && gimic.gimicData != null)
            {
                healthSystem.GetDamage(gimic.gimicData.Damage);
                if (gimic.gimicData.Stun == true)
                {
                    Stun(gimic.gimicData.StunDuration);
                    gimic.gimicData.Stun = false;
                }

                if (gimic.gimicData.DestroyOnHit)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void Stun(float duration)
    {
        print($"산타 장애물 맞아서 스턴이되");
    }
}
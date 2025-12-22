using System;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Players;
using Unity.VisualScripting;
using UnityEngine;

public class Santa : Agent
{
    [SerializeField] private float health = 100f;

    public HealthSystem HealthSystem { get; private set; }
    public SantaMove SantaMove { get; private set; }
    public Player player;

    public bool IsStun { get; private set; }

    private void Awake()
    {
        HealthSystem = GetComponent<HealthSystem>();
        SantaMove = GetComponent<SantaMove>();

        if (HealthSystem == null)
        {
            HealthSystem = gameObject.AddComponent<HealthSystem>();
        }

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(health);

        if (SantaMove != null)
        {
            SantaMove.Initialize(this);
            SantaMove.SetPlayer(player);
        }
        else
        {
            Debug.LogError("SantaMove component not found!");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ElectronicDisplayBoard"))
        {
            Gimic gimic = collision.gameObject.GetComponent<Gimic>();
            IsStun = true;
            if (gimic != null && gimic.gimicData != null)
            {
                HealthSystem.GetDamage(gimic.gimicData.Damage);

                if (HealthSystem.Health <= 0)
                {
                    BossDefeated();
                    return;
                }

                if (IsStun)
                {
                    Stun(gimic.gimicData.StunDuration);
                    SantaMove?.Knockback();
                    print("Santa is knockbacked!");
                    IsStun = false;
                }

                if (gimic.gimicData.DestroyOnHit)
                {
                    Destroy(collision.gameObject);
                }
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance?.GameOver();
        }
    }

    public void Stun(float duration)
    {
        if (IsStun) return;

        IsStun = true;
        Debug.Log($"Santa stunned for {duration} seconds!");

        Invoke(nameof(EndStun), duration);
    }

    private void EndStun()
    {
        IsStun = false;
        Debug.Log("Santa stun ended!");
    }

    private void BossDefeated()
    {
        Debug.Log("Santa Defeated!");
        GameManager.Instance?.Victory();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    private void OnDrawGizmos()
    {
        if (GameManager.Instance == null || player == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, player.transform.position);

        Gizmos.color = Color.yellow;
        Vector3 targetPos = transform.position + Vector3.right * 10f; Gizmos.DrawWireSphere(targetPos, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * 2f, 0.5f);
    }
}
using System;
using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Players;
using TransitionsPlus;
using Unity.VisualScripting;
using UnityEngine;

public class Santa : Agent
{
    [SerializeField] private double health = 100f;
    [SerializeField] private GameObject deathEffectPrefab;
    [SerializeField] private TransitionAnimator transitionAnimator;
    public SantaMove SantaMove { get; private set; }
    public Player player;
    public bool IsStun { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(health);

        HealthSystem.OnDead += SantaDie;

        SantaMove = GetComponent<SantaMove>();

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
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance?.GameOver();
        }
    }

    public void Stun(float duration)
    {
        SantaMove.enabled = false;
        IsStun = true;
        StartCoroutine(StopStun(duration));
    }

    private IEnumerator StopStun(float duration)
    {
        yield return new WaitForSeconds(duration);
        SantaMove.enabled = true;
        IsStun = false;
    }

    private void OnDestroy()
    {
        CancelInvoke();
        HealthSystem.OnDead -= SantaDie;
    }
    
    public void SantaDie()
    {
        transitionAnimator.gameObject.SetActive(true);
            SoundManager.Instance.Play(SFXSoundType.HURTSANTAR);
            print("��Ÿ����");
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            }
            Stun(2);
            health += 100;
            HealthSystem.SetHealth(health);
            print($"��ȭ�� ��Ÿ ü��: {HealthSystem.Health}");
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
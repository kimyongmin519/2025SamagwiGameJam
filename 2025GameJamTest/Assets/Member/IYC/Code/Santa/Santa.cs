using System;
using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Players;
using Unity.VisualScripting;
using UnityEngine;

public class Santa : Agent
{
    [SerializeField] private float health = 100f;

    public SantaMove SantaMove { get; private set; }
    public Player player;
    [SerializeField]
    private Rigidbody2D _rigi;

    public bool IsStun { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(health);

        SantaMove = GetComponent<SantaMove>();
        _rigi = GetComponent<Rigidbody2D>();

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
        _rigi.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(StopStun(duration));
        _rigi.constraints = RigidbodyConstraints2D.None;
    }

    private IEnumerator StopStun(float duration)
    {
        yield return new WaitForSeconds(duration);
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
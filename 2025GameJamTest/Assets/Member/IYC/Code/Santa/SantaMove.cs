using DG.Tweening;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Unity.VisualScripting;
using UnityEngine;
using Member.KYM.Code.Players;
using System.Collections;

public class SantaMove : MonoBehaviour, IAgentComponent
{
    [SerializeField] private float baseSpeed = 7;
    [SerializeField] private float farDistance = 10000000000000000000000000000000000f;
    [SerializeField] private float closeDistance = 2f;
    [SerializeField] private float farSpeedMultiplier = 100000f;
    [SerializeField] private float closeSpeedMultiplier = 1.1f;
    [SerializeField] private float catchDistance = 1f;
    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackDuration = 0.5f;

    private Player _player;
    private Agent _agent;
    private Santa _santa;
    private Rigidbody2D _rigidbody;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    private bool isSpeedUP = false;
    public void Initialize(Agent agent)
    {
        _agent = agent;
        _santa = agent as Santa;
        _rigidbody = agent.GetComponent<Rigidbody2D>();
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (_santa == null) return;
        if (GameManager.Instance == null || _player == null) return;

        if (isKnockedBack)
        {
            HandleKnockback();
            return;
        }

        if (_santa.IsStun)
        {
            StopMovement();
            return;
        }

        MoveRight();
        CheckCatchPlayer();
    }

    private void MoveRight()
    {
        float distanceToPlayer = _player.transform.position.x - transform.position.x;

        float currentSpeed = baseSpeed;

        if(isSpeedUP)
        {
            currentSpeed = baseSpeed * farSpeedMultiplier;
        }

        if (distanceToPlayer >= farDistance)
        {
            print("속도가 증가되었습니다.");
            currentSpeed = baseSpeed * farSpeedMultiplier;

            StartCoroutine(StaySpeed(9999999));
        }

        else if (distanceToPlayer <= closeDistance)
        {
            currentSpeed = baseSpeed * closeSpeedMultiplier;
        }

        transform.position += Vector3.right * currentSpeed * Time.fixedDeltaTime;
    }

    private IEnumerator StaySpeed(float time)
    {
        isSpeedUP = true;
        yield return new WaitForSeconds(time);
        isSpeedUP = false;
    }

    private void CheckCatchPlayer()
    {
        float distance = _player.transform.position.x - transform.position.x;

        if (distance <= catchDistance)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void Knockback()
    {
        if (isKnockedBack) return;

        isKnockedBack = true;
        knockbackTimer = knockbackDuration;

        if (_rigidbody != null)
        {
            _rigidbody.linearVelocityX = -knockbackForce;
        }
    }

    private void HandleKnockback()
    {
        knockbackTimer -= Time.fixedDeltaTime;

        if (knockbackTimer <= 0f)
        {
            isKnockedBack = false;
        }
    }

    private void StopMovement()
    {
        if (_rigidbody != null)
        {
            _rigidbody.linearVelocityX = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        if (GameManager.Instance == null || _player == null) return;

        float distance = _player.transform.position.x - transform.position.x;

        if (distance >= farDistance)
        {
            Gizmos.color = Color.red;
        }
        else if (distance <= closeDistance)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawLine(transform.position, _player.transform.position);
    }
}
using DG.Tweening;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Unity.VisualScripting;
using UnityEngine;
using Member.KYM.Code.Players;
using System.Collections;

public class SantaMove : MonoBehaviour, IAgentComponent
{
    [SerializeField] 
    private float baseSpeed = 6.5f;
    [SerializeField] 
    private float farDistance = 30;
    [SerializeField] 
    private float closeDistance = 2f;
    [SerializeField] 
    private float farSpeedMultiplier = 1;
    [SerializeField] 
    private float closeSpeedMultiplier = 1.1f;
    [SerializeField] 
    private float catchDistance = 7f;
    [SerializeField] 
    private float knockbackForce = 5f;
    [SerializeField] 
    private float knockbackDuration = 0.5f;
    [SerializeField] 
    private float boostTime = 1f;
    [SerializeField] 
    private float speedIncrease = 0f;
    private float timer;
    [SerializeField] private float timeSpeedBonus = 0f;

    private Player _player;
    private Santa _santa;
    private Rigidbody2D _rigidbody;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    private bool isSpeedUP = false;
    public void Initialize(Agent agent)
    {
        _santa = agent as Santa;
        _rigidbody = agent.GetComponent<Rigidbody2D>();
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_santa == null) return;
        if (GameManager.Instance == null || _player == null) return;

        if (_santa.IsStun)
        {
            StopMovement();
            return;
        }

        transform.position += Vector3.right * (MoveRight() + IncreaseSpeed()) * Time.deltaTime;
        CheckCatchPlayer();
    }

    private float MoveRight()
    {
        float distanceToPlayer = _player.transform.position.x - transform.position.x;
        float currentSpeed = baseSpeed;

        if (isSpeedUP)
        {
            currentSpeed = baseSpeed * farSpeedMultiplier;
        }

        if (distanceToPlayer >= farDistance)
        {
            print("�ӵ��� �����Ǿ����ϴ�.");
            StartCoroutine(speedUp());
            currentSpeed = baseSpeed * farSpeedMultiplier;
        }
        else if (distanceToPlayer <= closeDistance)
        {
            currentSpeed = baseSpeed * closeSpeedMultiplier;
        }

        return currentSpeed;
    }

    private IEnumerator speedUp()
    {
        isSpeedUP = true;
        yield return new WaitForSeconds(2);
        isSpeedUP = false;
    }

    private float IncreaseSpeed()
    {
        timer += Time.deltaTime;
        if (timer > boostTime)
        {
            timeSpeedBonus += speedIncrease;
            print($"����: {timeSpeedBonus}");
            timer = 0;
        }
        return timeSpeedBonus;
    }

    private void CheckCatchPlayer()
    {
        float distance = _player.transform.position.x - transform.position.x;

        if (distance <= catchDistance)
        {
            GameManager.Instance.GameOver();
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
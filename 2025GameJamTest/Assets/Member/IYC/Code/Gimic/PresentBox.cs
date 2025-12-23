using System;
using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PresentBox : Agent, IPoolable
{
    public UnityEvent OnBulletHit;
    private Rigidbody2D _rb;

    private float health = 1f;
    [SerializeField] private float lifeTime = 5f;

    public string ItemName => gameObject.name;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Reset()
    {
        if (_rb != null) _rb.linearVelocity = Vector2.zero;
    }

    private void OnEnable()
    {
        StartCoroutine(LifeCoroutine());
    }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(health);

        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            OnBulletHit.AddListener(() => scoreManager.AddScore(1));
        }
        else
        {
            print("없어 없다고 scoremanager가 없어!");
        }

        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        if(HealthSystem.Health <= 0)
        {
            Console.WriteLine("Bullet과의 충돌이 감지됨");
            OnBulletHit?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator LifeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.Push(this);
    }
}
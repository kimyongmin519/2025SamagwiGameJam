using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

public class ElectronicDisplayBoard : Agent, IPoolable
{
    private Rigidbody2D _rigi;
    public UnityEvent OnBulletHit;

    private float _stunCoolDown = 3f;

    [SerializeField]
    private float lifeTime = 2f;

    [SerializeField]
    private float currentHealth = 1;
    private bool isFall = false;
    public string ItemName => gameObject.name;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Reset()
    {
        if (_rigi != null)
        {
            _rigi.linearVelocity = Vector2.zero;
            _rigi.gravityScale = 0;
        }

        HealthSystem.SetHealth(currentHealth);
        isFall = false;
    }

    private void OnEnable()
    {
        _rigi.gravityScale = 0;
        StartCoroutine(LifeCoroutine());
    }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(currentHealth);

        _rigi = GetComponent<Rigidbody2D>();

        OnBulletHit.AddListener(() => FallEletronicDisplayBoard());
    }

    private void Update()
    {
        if (HealthSystem.Health <= 0)
        {
            OnBulletHit?.Invoke();
            isFall = true;
            print("¿¸±§∆« ¡◊¿Ω");
        }
    }

    private void FixedUpdate()
    {
        if (_rigi.linearVelocity.y > 0)
        {
            _rigi.linearVelocity = new Vector2(_rigi.linearVelocity.x, 0);
        }
    }
    private IEnumerator LifeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.Push(this);
    }

    private void FallEletronicDisplayBoard()
    {
        _rigi.gravityScale = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isFall)
        {
            if (collision.gameObject.TryGetComponent<Santa>(out Santa s))
            {
                print("Ω∫≈œ√≥∏Æ");
                s.Stun(_stunCoolDown);
                PoolManager.Instance.Push(this);
                isFall = false;
            }
            else if (collision.gameObject.TryGetComponent<GroundScroller>(out GroundScroller g))
            {
                PoolManager.Instance.Push(this);
            }
        }

    }
}

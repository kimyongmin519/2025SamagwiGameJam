using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using Member.KYM.Code.Weapon;
using UnityEngine;
using UnityEngine.Events;

public class ElectronicDisplayBoard : Agent, IPoolable
{
    private Rigidbody2D _rigi;
    public UnityEvent OnBulletHit;
    [SerializeField]
    private BoxCollider2D _collider;
    private float _stunCoolDown = 3f;
    [SerializeField]
    private float lifeTime = 2f;
    [SerializeField]
    private float currentHealth = 1;

    [SerializeField]
    private float hitAnimationDuration = 0.6f;

    private bool isFall = false;
    public string ItemName => gameObject.name;
    [SerializeField] private Animator animator;

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
        HealthSystem.OnDead -= FallDisplay;
        isFall = false;
        _collider.isTrigger = false;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _rigi.gravityScale = 0;
        HealthSystem.OnDead += FallDisplay;
        StartCoroutine(LifeCoroutine());
    }

    private IEnumerator LifeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.Push(this);
    }

    protected override void Awake()
    {
        base.Awake();
        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(currentHealth);
        _rigi = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        OnBulletHit.RemoveAllListeners();
    }

    private void FallDisplay()
    {
        OnBulletHit?.Invoke();
        print("Àü±¤ÆÇ Á×À½");

        StartCoroutine(WaitForAnimationThenFall());
    }

    private IEnumerator WaitForAnimationThenFall()
    {
        yield return new WaitForSeconds(hitAnimationDuration);

        FallEletronicDisplayBoard();
    }

    private void FixedUpdate()
    {
        if (_rigi.linearVelocity.y > 0)
        {
            _rigi.linearVelocity = new Vector2(_rigi.linearVelocity.x, 0);
        }
    }

    private void FallEletronicDisplayBoard()
    {
        _rigi.gravityScale = 2;
        _collider.isTrigger = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Santa>(out Santa s))
        {
            s.Stun(_stunCoolDown);
            animator.SetTrigger("Hit");
            isFall = false;
        }
        else if (collision.gameObject.TryGetComponent<infinitygameobject>(out infinitygameobject ig))
        {
            PoolManager.Instance.Push(this);
        }
        else if (!collision.gameObject.TryGetComponent<Bullet>(out Bullet b))
        {
            print($"{collision.gameObject}¿¡ ´ê¾Ò´Ù.");
            PoolManager.Instance.Push(this);
        }
    }
}
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
        HealthSystem.OnDead -= FallDisplay;

        isFall = false;
        _collider.isTrigger = false;
        
    }

    private void OnEnable()
    {
        _rigi.gravityScale = 0;
        StartCoroutine(LifeCoroutine());
        HealthSystem.OnDead += FallDisplay;
    }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(currentHealth);


        _rigi = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        OnBulletHit.AddListener(() => FallEletronicDisplayBoard());
    }

    private void FallDisplay()
    {
        OnBulletHit?.Invoke();
        print("Àü±¤ÆÇ Á×À½");
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
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Santa>(out Santa s))
        {
            print("±×³É ºÎ‹HÈû");
            s.Stun(_stunCoolDown);
            PoolManager.Instance.Push(this);
            isFall = false;
        }
        else if (!collision.gameObject.TryGetComponent<Bullet>(out Bullet b))
        {
            print($"{collision.gameObject}¿¡ ´ê¾Ò´Ù.");
            PoolManager.Instance.Push(this);
        }
    }

}

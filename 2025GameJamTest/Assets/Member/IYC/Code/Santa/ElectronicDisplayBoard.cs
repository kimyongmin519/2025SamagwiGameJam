using System.Collections;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

public class ElectronicDisplayBoard : Agent, IPoolable
{
    private Santa _santa;
    private Rigidbody2D _rigi;
    public UnityEvent OnBulletHit;

    private float _stunCoolDown = 3f;

    [SerializeField]
    private float lifeTime = 5f;
    
    [SerializeField]
    private float currentHealth = 1;
    
    public string ItemName => gameObject.name;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Reset()
    {
        if (_rigi != null) _rigi.linearVelocity = Vector2.zero;
    }

    private void OnEnable()
    {
        StartCoroutine(LifeCoroutine());
    }

    protected override void Awake()
    {
        base.Awake();

        HealthSystem.Initialize(this);
        HealthSystem.SetHealth(currentHealth);

        _rigi = GetComponent<Rigidbody2D>();
        _santa = FindAnyObjectByType<Santa>();

        _rigi.bodyType = RigidbodyType2D.Kinematic;

        OnBulletHit.AddListener(() => _santa.Stun(_stunCoolDown));
    }

    private void Update()
    {
        if(HealthSystem.Health <= 0)
        {
            print("");
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

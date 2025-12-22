using System.Collections;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PresentBox : MonoBehaviour, IPoolable
{
    [SerializeField] private float lifeTime = 5f;
    public UnityEvent OnBulletHit;
    private Rigidbody2D _rb;

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

    private void Awake()
    {
        ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();
        if (scoreManager != null)
        {
            OnBulletHit.AddListener(() => scoreManager.AddScore());
        }
        else
        {
            print("없어 없다고 score");
        }

        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private IEnumerator LifeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.Push(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            OnBulletHit?.Invoke();

            Destroy(collision.gameObject);
        }
    }
}
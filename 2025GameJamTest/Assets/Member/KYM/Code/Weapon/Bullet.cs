using System;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Member.KYM.Code.Weapon
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        [SerializeField] private BulletDataSO bulletData;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        private float _currentTime;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            _spriteRenderer.sprite = bulletData.BulletSprite;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (bulletData.BulletLifeTime < _currentTime)
            {
                Reset();
            }
        }

        public void ShootBullet(Vector2 dir)
        {
            _rigidbody2D.linearVelocity = dir * bulletData.BulletSpeed;
        }

        [field:SerializeField] public string ItemName { get;  private set; }
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Reset()
        {
            gameObject.SetActive(false);
            _currentTime = 0;
            _rigidbody2D.linearVelocity = Vector2.zero;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out HealthSystem healthSystem))
            {
                healthSystem.GetDamage(bulletData.Damage);
                
                GameObject effect = PoolManager.Instance.Pop("HitEffect").GetGameObject();
                    
                effect.transform.position = transform.position;
                effect.transform.rotation = Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)));
            }
            else
            {
                IPoolable effect = PoolManager.Instance.Pop("SnowExplotion");
                effect.GetGameObject().transform.position = transform.position;
            }
            Reset();
            PoolManager.Instance.Push(this);
        }
    }
}
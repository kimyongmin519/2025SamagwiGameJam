using System;
using Member.KYM.Code.Interface;
using UnityEngine;

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

        public string ItemName { get; }
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
    }
}
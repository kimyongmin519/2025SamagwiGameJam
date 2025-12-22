using System;
using System.Collections;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

namespace Member.SYW._01_Scripts.ETC
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Obstacle : MonoBehaviour, IPoolable
    {
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private float speed = 5f;
        private Rigidbody2D _rb;
        
        public string ItemName => gameObject.name;
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Reset()
        {
            
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity += Vector2.left * speed;
        }
        
        private IEnumerator LifeCoroutine()
        {
            yield return new WaitForSeconds(lifeTime);
            PoolManager.Instance.Push(this);
        }
    }
}
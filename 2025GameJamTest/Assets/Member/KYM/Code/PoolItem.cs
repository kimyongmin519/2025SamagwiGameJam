using System;
using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

namespace Member.KYM.Code
{
    public class PoolItem : MonoBehaviour, IPoolable
    {
        public string ItemName => gameObject.name;
        [SerializeField] private float lifeTime;
        private float _currentTime = 0;

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (lifeTime < _currentTime)
            {
                PoolManager.Instance.Push(this);   
            }
        }

        public void Reset()
        {
            _currentTime = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Member.KYM._02.Scripts.Interface;
using UnityEngine;

namespace Member.KYM._02.Scripts.Manager.Pooling
{
    public class Pool
    {
        private Stack<IPoolable> _pool;
        private Transform _parent;
        private GameObject _prefab;

        public Pool(Transform parent, GameObject prefab, int count)
        {
            _pool = new Stack<IPoolable>();
            _parent = parent;
            _prefab = prefab;

            for (int i = 0; i < count; i++)
            {
                GameObject obj = GameObject.Instantiate(prefab, _parent);
                obj.name = _prefab.name;
                obj.SetActive(false);
                _pool.Push(obj.GetComponent<IPoolable>());
            }
            
        }

        public IPoolable Pop()
        {
            IPoolable item = null;

            if (_pool.Count > 0)
            {
                item = _pool.Pop();
                item.GetGameObject().SetActive(true);
            }
            else
            {
                GameObject obj = GameObject.Instantiate(_prefab, _parent);
                obj.name = _prefab.name;
                
                item = obj.GetComponent<IPoolable>();
            }

            return item;
        }

        public void Push(IPoolable item)
        {
            item.Reset();
            item.GetGameObject().SetActive(false);
            _pool.Push(item);
        }
    }
}

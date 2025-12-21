using System.Collections.Generic;
using Member.KYM.Code.Interface;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.KYM.Code.Manager.Pooling
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        [SerializeField] private PoolItemListSO poolList;
        private Dictionary<string, Pool> _poolDit = new Dictionary<string, Pool>();

        protected override void Awake()
        {
            base.Awake();
            foreach (PoolItemSO item in poolList.PoolItems)
            {
                CreatePool(item.ItemPrefab, item.Count);
            }
        }

        private void CreatePool(GameObject prefab, int count)
        {
            IPoolable item = prefab.GetComponent<IPoolable>();
            
            Pool pool = new Pool(transform, prefab, count);
            
            _poolDit.Add(item.ItemName, pool);
        }

        public IPoolable Pop(string poolName)
        {
            if (_poolDit.ContainsKey(poolName))
            {
                IPoolable item = _poolDit[poolName].Pop();

                return item;
            }
            Debug.LogError("Nooooooooooooooooo PoolName Broooooooooooooo sadsad");
            return null;
        }
        
        public void Push(IPoolable item)
        {
            if (_poolDit.ContainsKey(item.ItemName))
            {
                _poolDit[item.ItemName].Push(item);
            }
            Debug.LogError("Noooooooooooo Poooooool Saaaaaaaans");
        }
    }
}

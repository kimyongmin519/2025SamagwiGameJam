using System;
using System.Collections.Generic;
using Member.KYM.Code.SO;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.KYM.Code.Manager.Pooling
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        [SerializeField] private PoolItemListSO poolList;
        private Dictionary<string, Pool> _poolDit = new Dictionary<string, Pool>();

        private void CreatePool(GameObject prefab, int count)
        {
            
        }
    }
}

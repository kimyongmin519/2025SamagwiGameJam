using System;
using Member.KYM._02.Scripts.Interface;
using UnityEngine;

namespace Member.KYM._02.Scripts.SO
{
    [CreateAssetMenu(fileName = "PoolItemSO", menuName = "KimSO/PoolItemSO")]
    public class PoolItemSO : ScriptableObject
    {
        [field: SerializeField] public string ItemName { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public GameObject ItemPrefab { get; private set; }

        private void OnValidate()
        {
            if (ItemPrefab.TryGetComponent(out IPoolable poolable))
            {
                ItemName = poolable.ItemName;
            }
            else
            {
                ItemPrefab = null;
                Debug.LogWarning("얘 IPoolable없엉!!!!!!!!!!!");
            }
        }
    }
}

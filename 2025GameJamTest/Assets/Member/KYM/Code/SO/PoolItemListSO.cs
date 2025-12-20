using System.Collections.Generic;
using UnityEngine;

namespace Member.KYM.Code.SO
{
    [CreateAssetMenu(fileName = "PoolItemList", menuName = "KimSO/PoolItemList")]
    public class PoolItemListSO : ScriptableObject
    {
        [field: SerializeField] public List<PoolItemSO> PoolItems { get; private set; }
    }
}

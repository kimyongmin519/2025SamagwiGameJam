using Member.KYM.Code.Manager.Pooling;
using UnityEngine;

[CreateAssetMenu(fileName = "PresentSO", menuName = "SO/PresentSO")]
public class PresentSO : PoolItemSO
{
    [field: SerializeField] public PresentBox Presentbox { get; set; }

}
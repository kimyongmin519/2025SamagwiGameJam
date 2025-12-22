using System.Collections.Generic;
using UnityEngine;

namespace Member.SYW._01_Scripts.Data
{
    [CreateAssetMenu(fileName = "PresentListSO", menuName = "SO/PresentListSO")]
    public class PresentListSO : ScriptableObject
    {
        [field:SerializeField] public List<PresentSO> PresentBox { get; set; }
    }
}
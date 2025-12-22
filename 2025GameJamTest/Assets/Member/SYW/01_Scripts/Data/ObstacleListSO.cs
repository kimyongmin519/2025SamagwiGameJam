using System.Collections.Generic;
using Member.SYW._01_Scripts.Data;
using UnityEngine;

namespace Member.SYW._01_Scripts.Data
{
    [CreateAssetMenu(fileName = "ObstacleListSO", menuName = "YeonSO/ObstacleListSO")]
    public class ObstacleListSO : ScriptableObject
    {
        [field: SerializeField] public List<ObstacleSO> Obstacles { get; set; }
    }
}
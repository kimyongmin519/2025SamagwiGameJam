using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PresentListSO", menuName = "SO/PresentListSO")]
public class PresentListSO : ScriptableObject
{
    [field: SerializeField] public List<PresentSO> presentSO { get; set; }
}
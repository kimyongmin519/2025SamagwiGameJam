using UnityEngine;

[CreateAssetMenu(fileName = "PresentSO", menuName = "SO/PresentSO")]
public class PresentSO : ScriptableObject
{
    [field: SerializeField] public PresentBox Presentbox { get; set; }

}
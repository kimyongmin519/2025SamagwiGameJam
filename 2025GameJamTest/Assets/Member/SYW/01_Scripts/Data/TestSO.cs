using UnityEngine;

namespace Member.SYW._01_Scripts.Data
{
    [CreateAssetMenu(fileName = "TestSO", menuName = "YeonSO/TestSO")]
    public class TestSO : ScriptableObject
    {
        [field:SerializeField] public string HalMal { get; set; }
    }
}

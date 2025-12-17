using UnityEngine;

namespace Member.KYM._02.Scripts.SO
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "KimSO/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        [field:SerializeField] public float CorrectionSpeed { get; private set; }
    }
}

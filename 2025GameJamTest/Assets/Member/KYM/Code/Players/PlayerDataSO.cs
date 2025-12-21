using UnityEngine;

namespace Member.KYM.Code.Players
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "KimSO/PlayerData")]
    public class PlayerDataSO : ScriptableObject
    {
        [field:SerializeField] public float CorrectionSpeed { get; private set; }
    }
}

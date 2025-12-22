using UnityEngine;

namespace Member.KYM.Code.Weapon
{
    [CreateAssetMenu(fileName = "GunDataSO", menuName = "KimSO/GunDataSO", order = 30)]
    public class GunDataSO : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float ShotDelay { get; private set; }
        [field:SerializeField] public int Ammo { get; private set; }

        [field: SerializeField] public Sprite GunSprite {get; private set;}

    }
}
using UnityEngine;

namespace Member.KYM.Code.Weapon
{
    [CreateAssetMenu(fileName = "BulletDataSO", menuName = "KimSO/BulletDataSO", order = 31)]
    public class BulletDataSO : ScriptableObject
    {
        [field:SerializeField] public float Damage { get; private set; }
        [field:SerializeField] public float BulletSpeed { get; private set; }
        [field:SerializeField] public float BulletLifeTime { get; private set; }
        [field:SerializeField] public Sprite BulletSprite { get; private set; }
    }
}
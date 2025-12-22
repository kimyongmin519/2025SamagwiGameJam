using UnityEngine;

[CreateAssetMenu(fileName = "Gimic", menuName = "SO/GimicSO")]
public class GimicSO : ScriptableObject
{
    public float Damage;                // 데미지
    public float StunDuration;          // 스턴
    public bool DestroyOnHit = true;    // 맞았을 때 부셔질까
}
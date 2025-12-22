using UnityEngine;

[CreateAssetMenu(fileName = "Gimic", menuName = "SO/GimicSO")]
public class GimicSO : ScriptableObject
{
    public float Damage = 10f;                // 데미지
    public float StunDuration = 2f;          // 스턴
    public bool DestroyOnHit = true;    // 맞았을 때 부셔질까
}
using NUnit.Framework;
using UnityEngine;

namespace Member.KYM.Code.Manager.SoundManager
{
    [CreateAssetMenu(fileName = "SoundSO", menuName = "KimSO/SoundSO", order = 16)]
    public class SoundDataSO : ScriptableObject
    {
        [field:SerializeField] public string SoundName { get; private set; }
        [field:SerializeField] public AudioClip Clip { get; private set; }
    }
}

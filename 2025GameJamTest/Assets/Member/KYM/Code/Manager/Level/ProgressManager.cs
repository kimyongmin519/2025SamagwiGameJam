using System;
using System.IO;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using Path = System.IO.Path;

namespace Member.KYM.Code.Manager.Level
{
    [Serializable]
    public class WeaponProgress
    {
        [field: SerializeField] public int GunDamageLevel { get; private set; } = 1;
        [field: SerializeField] public int GunAmmoLevel { get; private set; } = 1;
        [field: SerializeField] public int GunSpeedLevel { get; private set; } = 1;
        [field: SerializeField] public int GunReloadSpeedLevel { get; private set; } = 1;

    }
    public class ProgressManager : MonoSingleton<ProgressManager>
    {
        [field:SerializeField] public WeaponProgress WeaponProgress { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        [ContextMenu("Save To Json")]
        public void Save()
        {
            string jsonData = JsonUtility.ToJson(WeaponProgress);
            
            string path = Path.Combine(Application.dataPath, "GunProgress.json");
            
            File.WriteAllText(path, jsonData);
        }
        
        [ContextMenu("Load To Json")]
        public void Load()
        {
            string path = Path.Combine(Application.dataPath, "GunProgress.json");

            string jsonData = File.ReadAllText(path);

            WeaponProgress = JsonUtility.FromJson<WeaponProgress>(jsonData);
        }
        
    }
}

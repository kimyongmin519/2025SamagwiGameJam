using System;
using System.IO;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using Path = System.IO.Path;

namespace Member.KYM.Code.Manager.Level
{
    public enum UpgradeType
    {
        Damage,
        Ammo,
        Speed,
        Reload
    }
    
    [Serializable]
    public class WeaponProgress
    {
        [field: SerializeField] public int GunDamageLevel { get; private set; }
        [field: SerializeField] public int GunAmmoLevel { get; private set; }
        [field: SerializeField] public int GunSpeedLevel { get; private set; }
        [field: SerializeField] public int GunReloadSpeedLevel { get; private set; }

        public void LevelUp(UpgradeType _type)
        {
            switch (_type)
            {
                case UpgradeType.Ammo:
                    GunAmmoLevel++;
                    break;
                case UpgradeType.Reload:
                    GunReloadSpeedLevel++;
                    break;
                case UpgradeType.Speed:
                    GunSpeedLevel++;
                    break;
                case UpgradeType.Damage: 
                    GunDamageLevel++;
                    break;
            }
        }
    }
    public class ProgressManager : MonoSingleton<ProgressManager>
    {
        [field:SerializeField] public WeaponProgress WeaponProgress { get; private set; }

        private new void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            EventBus<WeaponUpgradeEvent>.OnEvent += Upgrade;
            EventBus<LevelSettingUIEvent>.Raise(new LevelSettingUIEvent());
            Load();
        }

        [ContextMenu("Save To Json")]
        public void Save()
        {
            string jsonData = JsonUtility.ToJson(WeaponProgress);
            
            string path = Path.Combine(Application.dataPath, "GunProgress.json");
            
            File.WriteAllText(path, jsonData);
            
            EventBus<GunSettingEvent>.Raise(new GunSettingEvent());
        }
        
        [ContextMenu("Load To Json")]
        public void Load()
        {
            string path = Path.Combine(Application.dataPath, "GunProgress.json");

            string jsonData = File.ReadAllText(path);

            WeaponProgress = JsonUtility.FromJson<WeaponProgress>(jsonData);
        }

        private void Upgrade(WeaponUpgradeEvent evt)
        {
            WeaponProgress.LevelUp(evt.upgradeType);
            Save();
        }

        public int ReturnLevelValue(UpgradeType upgradeType)
        {
            switch (upgradeType)
            {
                case UpgradeType.Ammo:
                    return WeaponProgress.GunAmmoLevel;
                case UpgradeType.Damage:
                    return WeaponProgress.GunDamageLevel;
                case UpgradeType.Speed:
                    return WeaponProgress.GunSpeedLevel;
                case UpgradeType.Reload:
                    return WeaponProgress.GunReloadSpeedLevel;
                default:
                    return 0;
            }
        }

        private new void OnDestroy()
        {
            base.OnDestroy();
            EventBus<WeaponUpgradeEvent>.OnEvent -= Upgrade;
        }
    }
}

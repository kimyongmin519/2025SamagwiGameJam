using System;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Member.KYM.Code.Manager.Level
{
    public class LevelText : MonoBehaviour
    {
        [SerializeField] private UpgradeType upType;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();

            EventBus<WeaponUpgradeEvent>.OnEvent += SetText;
        }

        private void Start()
        {
            SetText();
        }

        private void SetText(WeaponUpgradeEvent evt)
        {
            if (upType == evt.upgradeType)
                _text.SetText($"Lv:{ProgressManager.Instance.ReturnLevelValue(evt.upgradeType)}");
        }
        
        private void SetText()
        {
            _text.SetText($"Lv:{ProgressManager.Instance.ReturnLevelValue(upType)}");
        }
        

        private void OnDestroy()
        {
            EventBus<WeaponUpgradeEvent>.OnEvent -= SetText;
        }
    }
}

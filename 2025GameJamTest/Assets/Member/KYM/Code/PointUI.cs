using System;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Member.KYM.Code
{
    public class PointUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;
        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();

            EventBus<WeaponUpgradeEvent>.OnEvent += SetText;
        }
        
        private void SetText(WeaponUpgradeEvent evt)
        {
            _textMeshPro.SetText($"남은 포인트: {PlayerPrefs.GetInt("UpgradePoint")}");
        }

        private void OnDestroy()
        {
            EventBus<WeaponUpgradeEvent>.OnEvent -= SetText;

        }
    }
}

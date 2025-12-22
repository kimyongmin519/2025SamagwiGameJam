using Member.KYM.Code.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class AmmoUI : MonoBehaviour
    {
        private Gun _gun;
        private Slider _slider;
        private TextMeshProUGUI _ammoText;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _ammoText = GetComponentInChildren<TextMeshProUGUI>();
            _gun = GameObject.Find("Gun").GetComponent<Gun>();
        }

        private void Start()
        {
            _slider.value = _gun.Ammo;
        }

        private void Update()
        {
            _slider.value = _gun.Ammo;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class AmmoUI : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
    }
}
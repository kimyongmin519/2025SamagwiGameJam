using System;
using DG.Tweening;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Member.SYW._01_Scripts.UI
{
    public class EditPanel : MonoSingleton<EditPanel>
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Button button;
        [SerializeField] private AudioMixer audioMixer;
        
        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            button.DOKill();
        }
    }
}
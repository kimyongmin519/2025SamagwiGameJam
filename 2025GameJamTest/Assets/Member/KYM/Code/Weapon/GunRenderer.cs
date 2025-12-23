using System;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using UnityEditor.Embree;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code.Weapon
{
    public class GunRenderer : MonoBehaviour
    {
        private Transform _trm;
        private Animator _animator;
        private readonly int _reloadHash = Animator.StringToHash("Reload");

        public void Initialize(Transform trm)
        {
            _trm = trm;
            _animator = GetComponent<Animator>();
        }

        public void ReloadAnim()
        {
            EventBus<AmmoResetEvent>.Raise(new AmmoResetEvent());
            _animator.SetTrigger(_reloadHash);
        }

        public void ReloadSuccess()
        {
            EventBus<ReloadEndEvent>.Raise(new ReloadEndEvent());
        }

        public void FlipControl(float xDir)
        {
            float targetYScale = xDir > 0 ? 1 : -1;
            _trm.transform.localScale = new Vector3(_trm.transform.localScale.x, targetYScale
                ,_trm.transform.localScale.z);
        }

        public void SetAnimSpeed(float speed)
        {
            _animator.speed = speed;
        }

        public void PlaySound(int index)
        {
            switch (index)
            {
                case 0:
                    SoundManager.Instance.Play(SFXSoundType.GUNSPIN);
                    break;
                case 1:
                    SoundManager.Instance.Play(SFXSoundType.GUNRELOAD);
                    break;
            }
        }
    }
}

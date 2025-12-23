using System.Collections;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Manager.Level;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Member.KYM.Code.Weapon
{
    public class Gun : MonoBehaviour
    {
        private UpgradeValues _upgradeValues = new UpgradeValues();
        [SerializeField] private GunDataSO gunData;
        [SerializeField] private Transform firePoint;
        public GunRenderer Renderer { get; private set; }
        private Vector2 _mousePos;
        private Vector2 _mouseDir;

        private int _maxAmmo;
        private int _ammo;

        public int Ammo
        {
            get => _ammo;
            private set
            {
                int before = _ammo;
                if (value != before)
                {
                    EventBus<AmmoReturnEvent>.Raise(new AmmoReturnEvent(value));
                }

                _ammo = value;
            }
        }

        private float _gunDelay;

        public float GunDelay
        {
            get => _gunDelay;
            set { _gunDelay = Mathf.Clamp(value, 0.001f, gunData.ShotDelay); }
        }

        private int _bulletCount;

        public UnityEvent OnShootEvent;

        private void Awake()
        {
            Renderer = GetComponentInChildren<GunRenderer>();

            Renderer.Initialize(transform);

            _bulletCount = gunData.BulletCount;
            _gunDelay = gunData.ShotDelay;

            EventBus<ReloadEndEvent>.OnEvent += Reload;
            EventBus<AmmoResetEvent>.OnEvent += ResetAmmo;
            EventBus<GunSettingEvent>.OnEvent += SetGunLevel;
        }

        private void Start()
        {
            _upgradeValues.gunAmmoLevel = ProgressManager.Instance.WeaponProgress.GunAmmoLevel;
            _upgradeValues.gunDamageLevel = ProgressManager.Instance.WeaponProgress.GunDamageLevel;
            _upgradeValues.gunSpeedLevel = ProgressManager.Instance.WeaponProgress.GunSpeedLevel;
            _upgradeValues.gunReloadSpeedLevel = ProgressManager.Instance.WeaponProgress.GunReloadSpeedLevel;

            _maxAmmo = gunData.Ammo + (10 * _upgradeValues.gunAmmoLevel);
            Ammo = _maxAmmo;

            Renderer.SetAnimSpeed(1 + (_upgradeValues.gunReloadSpeedLevel * 0.2f));
        }

        private void Update()
        {
            _mouseDir = (_mousePos - (Vector2)transform.position).normalized;
            Renderer.FlipControl(_mouseDir.x);

            float angle = Mathf.Atan2(_mouseDir.y, _mouseDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        public void SetMousePos(Vector2 mouseDir)
        {
            _mousePos = mouseDir;
        }

        private bool _shoot = false;

        public void Shoot()
        {
            _shoot = true;
            StartCoroutine(ShootCor());
        }

        private IEnumerator ShootCor()
        {
            while (_shoot && Ammo > 0)
            {
                ShootBullet();
                yield return new WaitForSeconds(GunDelay - (0.01f * _upgradeValues.gunSpeedLevel));
            }
        }

        private void ShootBullet()
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    SoundManager.Instance.Play(SFXSoundType.GUNSHOT1);
                    break;
                case 1:
                    SoundManager.Instance.Play(SFXSoundType.GUNSHOT2);
                    break;
                case 2:
                    SoundManager.Instance.Play(SFXSoundType.GUNSHOT3);
                    break;
                case 3:
                    SoundManager.Instance.Play(SFXSoundType.GUNSHOT4);
                    break;
            }
            OnShootEvent?.Invoke();

            Ammo--;

            float errorValue = Random.Range(-gunData.GunAccuracy, gunData.GunAccuracy);

            for (int i = 0; i < _bulletCount; i++)
            {
                GameObject bullet = PoolManager.Instance.Pop("Bullet").GetGameObject();
                bullet.transform.position = firePoint.position;
                bullet.GetComponent<Bullet>().ShootBullet((_mouseDir + new Vector2(errorValue, 0)).normalized);
            }
        }

        public void StopShoot()
        {
            _shoot = false;
        }

        private void ResetAmmo(AmmoResetEvent evt)
        {
            Ammo = 0;
        }

        public void Reload(ReloadEndEvent evt)
        {
            Ammo = _maxAmmo;
        }

        private void SetGunLevel(GunSettingEvent evt)
        {
            _upgradeValues.gunAmmoLevel = ProgressManager.Instance.WeaponProgress.GunAmmoLevel;
            _upgradeValues.gunDamageLevel = ProgressManager.Instance.WeaponProgress.GunDamageLevel;
            _upgradeValues.gunSpeedLevel = ProgressManager.Instance.WeaponProgress.GunSpeedLevel;
            _upgradeValues.gunReloadSpeedLevel = ProgressManager.Instance.WeaponProgress.GunReloadSpeedLevel;
            
            _maxAmmo = gunData.Ammo + (10 * _upgradeValues.gunAmmoLevel);

            Renderer.SetAnimSpeed(1 + (_upgradeValues.gunReloadSpeedLevel * 0.2f));
        }

    private void OnDestroy()
        {
            EventBus<ReloadEndEvent>.OnEvent -= Reload;
            EventBus<AmmoResetEvent>.OnEvent -= ResetAmmo;
        }
    }
}

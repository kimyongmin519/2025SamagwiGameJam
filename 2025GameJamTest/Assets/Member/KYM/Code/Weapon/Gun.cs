using System.Collections;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

namespace Member.KYM.Code.Weapon
{
    public class Gun : MonoBehaviour
    {
        [field:SerializeField] public GunDataSO GunData { get; private set; }
        [SerializeField] private Transform firePoint;
        public GunRenderer Renderer {get; private set;}
        private Vector2 _mousePos;
        private Vector2 _mouseDir;

        private int _ammo;

        public int Ammo
        {
            get => _ammo;
            set
            {
                int before = _ammo;
                if (value != before)
                {
                    EventBus<AmmoReturnEvent>.Raise(new AmmoReturnEvent(value));
                }
                _ammo = value;
            }
        }
        
        private int _bulletCount;

        public UnityEvent OnShootEvent;

        private void Awake()
        {
            Renderer = GetComponentInChildren<GunRenderer>();
            
            Renderer.Initialize(transform);

            _bulletCount = GunData.BulletCount;
            Ammo = GunData.Ammo;

            EventBus<ReloadEndEvent>.OnEvent += Reload;
        }

        private void Update()
        {
            _mouseDir = (_mousePos - (Vector2)transform.position).normalized;
            Renderer.FlipControl(_mouseDir.x);
            
            float angle = Mathf.Atan2(_mouseDir.y,_mouseDir.x) * Mathf.Rad2Deg;

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
                yield return new WaitForSeconds(GunData.ShotDelay);
            }
        }

        private void ShootBullet()
        {
            OnShootEvent?.Invoke();

            Ammo--;
            
            for (int i = 0; i < _bulletCount; i++)
            {
                GameObject bullet = PoolManager.Instance.Pop("Bullet").GetGameObject();
                bullet.transform.position = firePoint.position;
                bullet.GetComponent<Bullet>().ShootBullet(_mouseDir);
            }
        }
        public void StopShoot()
        {
            _shoot = false;
        }

        public void Reload(ReloadEndEvent evt)
        {
            Ammo = GunData.Ammo;
        }

        private void OnDestroy()
        {
            EventBus<ReloadEndEvent>.OnEvent -= Reload;
        }
    }
}

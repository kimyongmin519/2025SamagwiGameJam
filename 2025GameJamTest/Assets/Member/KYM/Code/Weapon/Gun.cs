using Member.KYM.Code.Interface;
using Member.KYM.Code.Manager.Pooling;
using UnityEngine;
using UnityEngine.Events;

namespace Member.KYM.Code.Weapon
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private GunDataSO gunData;
        [SerializeField] private Transform firePoint;
        private Vector2 _mousePos;
        private Vector2 _mouseDir;
        private GunRenderer _renderer;
        
        private int _bulletCount;

        public UnityEvent OnShootEvent;

        private void Awake()
        {
            _renderer = GetComponentInChildren<GunRenderer>();
            
            _renderer.Initialize(transform);

            _bulletCount = gunData.BulletCount;
        }

        private void Update()
        {
            _mouseDir = (_mousePos - (Vector2)transform.position).normalized;
            _renderer.FlipControl(_mouseDir.x);
            
            float angle = Mathf.Atan2(_mouseDir.y,_mouseDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
        public void SetMousePos(Vector2 mouseDir)
        {
            _mousePos = mouseDir;
        }

        public void Shoot()
        {
            OnShootEvent?.Invoke();

            for (int i = 0; i < _bulletCount; i++)
            {
                GameObject bullet = PoolManager.Instance.Pop("Bullet").GetGameObject();
                bullet.transform.position = firePoint.position;
                bullet.GetComponent<Bullet>().ShootBullet(_mouseDir);
            }
        }
    }
}

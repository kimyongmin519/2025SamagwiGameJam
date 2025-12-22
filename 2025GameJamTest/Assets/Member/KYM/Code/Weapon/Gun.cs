using UnityEngine;

namespace Member.KYM.Code.Weapon
{
    public class Gun : MonoBehaviour
    {
        private Vector2 _mousePos;
        private GunRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponentInChildren<GunRenderer>();
            
            _renderer.Initialize(transform);
        }

        private void Update()
        {
            Vector2 dir = (_mousePos - (Vector2)transform.position).normalized;
            _renderer.FlipControl(dir.x);
            
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
        public void SetMousePos(Vector2 mouseDir)
        {
            _mousePos = mouseDir;
        }
        
    }
}

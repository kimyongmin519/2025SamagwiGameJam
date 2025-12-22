using UnityEngine;

namespace Member.KYM.Code.Weapon
{
    public class Gun : MonoBehaviour
    {
        private Vector2 _mouseDir;

        private void Update()
        {
            float angle = Mathf.Atan2(_mouseDir.y, _mouseDir.x) * Mathf.Rad2Deg;
            
            //transform.rotation = Quaternion.Euler(new Vector3(0,0,))
        }
        public void SetMouseDir(Vector2 mouseDir)
        {
            _mouseDir = mouseDir;
        }
        
    }
}

using Member.KYM.Code.Weapon;
using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class Hand : MonoBehaviour
    {
        public Gun Gun { get; private set; }
        private Vector2 _mousePos;
        private float _defaultY;

        private void Awake()
        {
            Gun = GetComponentInChildren<Gun>();
            _defaultY = transform.localPosition.y;
        }

        private void Update()
        {
            Gun.SetMousePos(_mousePos);

            Vector2 bonusPos = (_mousePos - (Vector2)transform.position) / 100f;

            transform.localPosition = new Vector2(0,_defaultY) + bonusPos;
        }

        public void SetMousePos(Vector2 dir)
        {
            _mousePos = dir;
        }
    }
}

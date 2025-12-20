using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class AgentMovement : MonoBehaviour
    {
        private Vector2 _moveDir = Vector2.zero;
        private float _speed;
        public Rigidbody2D RbCompo {get; private set;}

        private void Awake()
        {
            RbCompo = GetComponent<Rigidbody2D>();
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetMoveDir(Vector2 moveDir)
        {
            _moveDir = moveDir.normalized;
        }
        
        private void FixedUpdate()
        {
            RbCompo.linearVelocity = _moveDir * _speed;
        }
    }
}

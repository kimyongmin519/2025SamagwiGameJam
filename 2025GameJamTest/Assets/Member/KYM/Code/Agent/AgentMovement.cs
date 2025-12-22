using System;
using Member.KYM.Code.Interface;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public class AgentMovement : MonoBehaviour, IAgentComponent
    {
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Vector2 groundCheckSize;
        [SerializeField] private float fallTime;

        private int _jumpCount = 2;
        
        private float _airborneTime;
        
        private Agent _agent;
        private Rigidbody2D _rigidbody2D;

        private float _xDir;
        private float _speed;
        private float _jumpPower;

        [SerializeField] private bool isGround;
        
        public void Initialize(Agent agent)
        {
            _agent = agent;
            _rigidbody2D = agent.GetComponent<Rigidbody2D>();
        }
        
        public void SetXDir(float dir) => _xDir = dir;
        public void SetSpeed(float speed) => _speed = speed;
        public void SetJumpPower(float power) => _jumpPower = power;

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocityX = _xDir * _speed;

            GroundCheck();

            if (!isGround)
            {
                _airborneTime += Time.fixedDeltaTime;

                if (fallTime <= _airborneTime)
                    _rigidbody2D.AddForceY(-1, ForceMode2D.Impulse);

            }
            else
            {
                _airborneTime = 0;
                _jumpCount = 2;
            }
                
        }

        private void GroundCheck()
            => isGround = Physics2D.OverlapBox(transform.position, groundCheckSize, 0, whatIsGround);
        public void Jump()
        {
            _jumpCount--;
            
            if (_jumpCount <= 0) return;
            
            _rigidbody2D.linearVelocityY = 0;
            _airborneTime = 0;
            _rigidbody2D.AddForceY(_jumpPower, ForceMode2D.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position,groundCheckSize);
        }
    }
}
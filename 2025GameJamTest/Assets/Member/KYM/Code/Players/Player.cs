using System;
using Member.KYM.Code.Agent;
using Member.KYM.Code.Weapon;
using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class Player : Agent.Agent
    {
        [field:SerializeField] public PlayerInputSO PlayerInput { get; private set; }
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        public AgentMovement AgentMovement { get; private set; }
        public AgentRenderer AgentRenderer { get; private set; }
        private Hand _hand;

        private bool _isAttack = false;

        private void Awake()
        {
            AgentMovement = GetComponentInChildren<AgentMovement>();
            AgentRenderer = GetComponentInChildren<AgentRenderer>();
            _hand = GetComponentInChildren<Hand>();
            
            AgentMovement.Initialize(this);
            AgentRenderer.Initialize(this);
            
            AgentMovement.SetJumpPower(jumpPower);
        }

        private void Start()
        {
            PlayerInput.OnJumpPressed += AgentMovement.Jump;
            PlayerInput.OnAttackPressed += _hand.Gun.Shoot;
            PlayerInput.OnAttackReleased += _hand.Gun.StopShoot;
            PlayerInput.OnReloadPressed += _hand.Gun.Renderer.ReloadAnim;
            PlayerInput.OnAttackPressed += AttackTrue;
            PlayerInput.OnAttackReleased += AttackFalse;
        }

        private void Update()
        {
            if (_isAttack && _hand.Gun.Ammo > 0)
                AgentMovement.SetSpeed(speed / 1.5f);
            else
                AgentMovement.SetSpeed(speed);
            
            AgentRenderer.FlipControl(PlayerInput.MousePos.x);
            AgentMovement.SetXDir(PlayerInput.MoveDir.x);
            _hand.SetMousePos(PlayerInput.MousePos);
        }
        
        private void AttackTrue() => _isAttack = true;
        private void AttackFalse() => _isAttack = false;

        private void OnDestroy()
        {
            PlayerInput.OnJumpPressed -= AgentMovement.Jump;
            PlayerInput.OnAttackPressed -= _hand.Gun.Shoot;
            PlayerInput.OnAttackReleased -= _hand.Gun.StopShoot;
            PlayerInput.OnReloadPressed -= _hand.Gun.Renderer.ReloadAnim;
            PlayerInput.OnAttackPressed -= AttackTrue;
            PlayerInput.OnAttackReleased -= AttackFalse;
        }
    }
}

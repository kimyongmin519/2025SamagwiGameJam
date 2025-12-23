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
        private Gun _gun;

        private bool _isAttack = false;

        private void Awake()
        {
            AgentMovement = GetComponentInChildren<AgentMovement>();
            AgentRenderer = GetComponentInChildren<AgentRenderer>();
            _gun = GetComponentInChildren<Gun>();
            
            AgentMovement.Initialize(this);
            AgentRenderer.Initialize(this);
            
            AgentMovement.SetJumpPower(jumpPower);
        }

        private void Start()
        {
            PlayerInput.OnJumpPressed += AgentMovement.Jump;
            PlayerInput.OnAttackPressed += _gun.Shoot;
            PlayerInput.OnAttackReleased += _gun.StopShoot;
            PlayerInput.OnReloadPressed += _gun.Renderer.ReloadAnim;
            PlayerInput.OnAttackPressed += AttackTrue;
            PlayerInput.OnAttackReleased += AttackFalse;
        }

        private void Update()
        {
            if (_isAttack && _gun.Ammo > 0)
                AgentMovement.SetSpeed(speed / 1.5f);
            else
                AgentMovement.SetSpeed(speed);
            
            AgentRenderer.FlipControl(PlayerInput.MousePos.x);
            AgentMovement.SetXDir(PlayerInput.MoveDir.x);
            _gun.SetMousePos(PlayerInput.MousePos);
        }
        
        private void AttackTrue() => _isAttack = true;
        private void AttackFalse() => _isAttack = false;

        private void OnDestroy()
        {
            PlayerInput.OnJumpPressed -= AgentMovement.Jump;
            PlayerInput.OnAttackPressed -= _gun.Shoot;
            PlayerInput.OnAttackReleased -= _gun.StopShoot;
            PlayerInput.OnReloadPressed -= _gun.Renderer.ReloadAnim;
            PlayerInput.OnAttackPressed -= AttackTrue;
            PlayerInput.OnAttackReleased -= AttackFalse;
        }
    }
}

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
        public HealthSystem HealthSystem { get; private set; }
        public AgentMovement AgentMovement { get; private set; }
        public AgentRenderer AgentRenderer { get; private set; }
        private Hand _hand;

        private void Awake()
        {
            HealthSystem = GetComponent<HealthSystem>();
            AgentMovement = GetComponentInChildren<AgentMovement>();
            AgentRenderer = GetComponentInChildren<AgentRenderer>();
            _hand = GetComponentInChildren<Hand>();
            
            AgentMovement.Initialize(this);
            AgentRenderer.Initialize(this);
            
            AgentMovement.SetSpeed(speed);
            AgentMovement.SetJumpPower(jumpPower);
        }

        private void Start()
        {
            PlayerInput.OnJumpPressed += AgentMovement.Jump;
            PlayerInput.OnAttackPressed += _hand.Gun.Shoot;
            PlayerInput.OnAttackReleased += _hand.Gun.StopShoot;
        }

        private void Update()
        {
            AgentMovement.SetXDir(PlayerInput.MoveDir.x);
            _hand.SetMousePos(PlayerInput.MousePos);
        }

        private void OnDestroy()
        {
            PlayerInput.OnJumpPressed -= AgentMovement.Jump;
            PlayerInput.OnAttackPressed -= _hand.Gun.Shoot;
            PlayerInput.OnAttackReleased -= _hand.Gun.StopShoot;
        }
    }
}

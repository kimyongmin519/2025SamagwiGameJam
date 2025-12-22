using System;
using Member.KYM.Code.Agent;
using UnityEngine;

namespace Member.KYM.Code.Players
{
    public class Player : Agent.Agent
    {
        [SerializeField] private PlayerInputSO playerInput;
        [SerializeField] private float speed;
        [SerializeField] private float jumpPower;
        public HealthSystem HealthSystem { get; private set; }
        public AgentMovement AgentMovement { get; private set; }
        public AgentRenderer AgentRenderer { get; private set; }

        private void Awake()
        {
            HealthSystem = GetComponent<HealthSystem>();
            AgentMovement = GetComponentInChildren<AgentMovement>();
            AgentRenderer = GetComponentInChildren<AgentRenderer>();
            
            AgentMovement.Initialize(this);
            AgentRenderer.Initialize(this);
            
            AgentMovement.SetSpeed(speed);
            AgentMovement.SetJumpPower(jumpPower);

            playerInput.OnJumpPressed += AgentMovement.Jump;
        }

        private void Update()
        {
            AgentMovement.SetXDir(playerInput.MoveDir);
        }

        private void OnDestroy()
        {
            playerInput.OnJumpPressed -= AgentMovement.Jump;
        }
    }
}

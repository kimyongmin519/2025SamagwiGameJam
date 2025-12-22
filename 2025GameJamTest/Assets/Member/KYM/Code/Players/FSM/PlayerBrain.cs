using System;
using UnityEngine;

namespace Member.KYM.Code.Players.FSM
{
    public class PlayerBrain : MonoBehaviour
    {
        private Player _player;
        private PlayerStateMachine _stateMachine;
        private void Awake()
        { 
            _player = GetComponent<Player>();
            _stateMachine = new PlayerStateMachine();
            
            _stateMachine.AddState(PlayerStateType.Idle, new PlayerIdleState(_player, _stateMachine, "Idle"));
            _stateMachine.AddState(PlayerStateType.Walk, new PlayerWalkState(_player, _stateMachine, "Walk"));
            _stateMachine.AddState(PlayerStateType.Jump, new PlayerJumpState(_player, _stateMachine, "Jump"));
            _stateMachine.AddState(PlayerStateType.Fall, new PlayerFallState(_player, _stateMachine, "Fall"));
        }

        private void Start()
        {
            _stateMachine.Initialize(PlayerStateType.Idle);
        }

        private void Update()
        {
            _stateMachine.CurrentState.UpdateState();

            bool isGround = _player.AgentMovement.GetIsGround();

            if (Mathf.Abs(_player.PlayerInput.MoveDir.x) > 0 && isGround)
            {
                _stateMachine.ChangeState(PlayerStateType.Walk);
            }
            else if (!isGround)
            {
                if (_player.AgentMovement.GetYVelocity() > 0)
                {
                    _stateMachine.ChangeState(PlayerStateType.Jump);
                }
                else
                {
                    _stateMachine.ChangeState(PlayerStateType.Fall);
                }
            }
            else
            {
                _stateMachine.ChangeState(PlayerStateType.Idle);
            }
        }
        
    }
}
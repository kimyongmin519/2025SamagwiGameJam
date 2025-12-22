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
            
            //_stateMachine.AddState(PlayerStateType.Idle);
        }
    }
}
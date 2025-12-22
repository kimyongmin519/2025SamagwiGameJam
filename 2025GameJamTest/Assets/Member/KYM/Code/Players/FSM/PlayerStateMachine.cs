using System.Collections.Generic;
using UnityEngine;

namespace Member.KYM.Code.Players.FSM
{
    public enum PlayerStateType
    {
        Idle,
        Walk,
        Jump,
        Fall
    }
    
    public class PlayerStateMachine
    {
        private Dictionary<PlayerStateType, PlayerState> _stateDict = new Dictionary<PlayerStateType, PlayerState>();
        public PlayerState CurrentState { get; private set; }

        public void Initialize(PlayerStateType stateType)
        {
            CurrentState = _stateDict[stateType];
        }
        
        public void ChangeState(PlayerStateType type)
        {
            if (CurrentState == null) return;
            
            CurrentState.ExitState();
            if (_stateDict.ContainsKey(type))
            {
                CurrentState = _stateDict[type];
                CurrentState.EnterState();
            }
        }
        
        public void AddState(PlayerStateType type, PlayerState state)
        {
            _stateDict.Add(type, state);
        }
    }
}
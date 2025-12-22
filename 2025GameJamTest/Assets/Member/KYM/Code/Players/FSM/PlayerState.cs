using UnityEngine;

namespace Member.KYM.Code.Players.FSM
{
    public class PlayerState
    {
        protected Player Player;
        protected PlayerStateMachine StateMachine;
        protected string AnimParam;

        public PlayerState(Player player, PlayerStateMachine stateMachine, string animParam)
        {
            Player = player;
            StateMachine = stateMachine;
            AnimParam = animParam;
        }
            

        public virtual void EnterState()
        {
            Player.AgentRenderer.Animator.SetBool(AnimParam, true);
        }

        public virtual void UpdateState()
        {
            
        }
    
        public virtual void ExitState()
        {
            Player.AgentRenderer.Animator.SetBool(AnimParam, false);
        }
    }
}

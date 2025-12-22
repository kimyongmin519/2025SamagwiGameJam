using UnityEngine;

namespace Member.KYM.Code.Players.FSM
{
    public class PlayerWalkState : PlayerState
    {
        public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string animParam) : base(player, stateMachine, animParam)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}

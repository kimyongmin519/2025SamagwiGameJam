using Member.KYM.Code.Interface;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public class AgentRenderer : MonoBehaviour, IAgentComponent
    {
        private Agent _agent;
        private Animator _animator;

        private float _facingDirection = 1;
        
        public void Initialize(Agent agent)
        {
            _agent = agent;
            _animator = GetComponent<Animator>();
        }

        public void FlipControl(float xMove)
        {
            if (Mathf.Abs(_facingDirection + xMove) > 1)
            {
                
            }
        }

        public void FlipX()
        {
            
        }
        
    }
}
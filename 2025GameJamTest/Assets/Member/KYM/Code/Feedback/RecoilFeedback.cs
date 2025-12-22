using UnityEngine;

namespace Member.KYM.Code.Feedback
{
    public class RecoilFeedback : Feedback
    {
        [SerializeField] private Transform trm;

        public override void CreateFeedback()
        {
            
        }

        public override void FinishFeedback()
        {
            throw new System.NotImplementedException();
        }
    }
}

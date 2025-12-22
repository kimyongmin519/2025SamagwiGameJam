using System.Collections.Generic;
using UnityEngine;

namespace Member.KYM.Code.Feedback
{
    public class FeedbacksPlayer : MonoBehaviour
    {
        [SerializeField] private List<Feedback> feedbacks;

        public void PlayerFeedbacks()
        {
            feedbacks.ForEach(feedback => feedback.FinishFeedback());
            feedbacks.ForEach(feedback => feedback.CreateFeedback());
        }
    }
}
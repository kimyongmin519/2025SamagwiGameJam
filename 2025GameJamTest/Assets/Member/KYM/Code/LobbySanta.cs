using DG.Tweening;
using TransitionsPlus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Member.KYM.Code
{
    public class LobbySanta : MonoBehaviour
    {
        [SerializeField] private TransitionAnimator transition;
        
        public void Move(Transform goal)
        {
            Sequence s = DOTween.Sequence();
            
            s.Append(transform.DOMove(goal.position, 0.1f).SetEase(Ease.Linear));
            s.AppendInterval(1f);
            s.AppendCallback(() => transition.gameObject.SetActive(true));
        }
    }
}

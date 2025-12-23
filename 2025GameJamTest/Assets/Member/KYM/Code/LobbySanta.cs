using DG.Tweening;
using UnityEngine;

namespace Member.KYM.Code
{
    public class LobbySanta : MonoBehaviour
    {
        public void Move(Transform goal)
        {
            transform.DOMove(goal.position, 0.1f).SetEase(Ease.Linear);
        }
    }
}

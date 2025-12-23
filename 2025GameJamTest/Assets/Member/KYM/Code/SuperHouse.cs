using UnityEngine;
using DG.Tweening;

namespace Member.KYM.Code
{
    public class SuperHouse : MonoBehaviour
    {
        [SerializeField] private Transform goal;
        
        public void SpinBoooooom()
        {
            transform.DOMove(goal.position, 0.5f).SetEase(Ease.Linear);
            transform.DORotate(new Vector3(0,0,3600), 0.5f,RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
    }
}

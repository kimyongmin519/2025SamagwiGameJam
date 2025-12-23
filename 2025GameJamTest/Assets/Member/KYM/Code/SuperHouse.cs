using System;
using UnityEngine;
using DG.Tweening;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Manager.Level;

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

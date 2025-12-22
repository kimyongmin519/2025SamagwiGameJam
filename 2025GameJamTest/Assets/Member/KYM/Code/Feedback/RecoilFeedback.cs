using System;
using DG.Tweening;
using UnityEngine;

namespace Member.KYM.Code.Feedback
{
    public class RecoilFeedback : Feedback
    {
        [SerializeField] private Transform trm;
        [SerializeField] private float recoilAmount;
        [SerializeField] private float recoilDuration;
        
        private Tween _recoilTween;
        private Vector2 _initPos;

        private void Awake()
        {
            _initPos = trm.localPosition;
        }

        public override void CreateFeedback()
        {
            float targetX = _initPos.x - recoilAmount;
            _recoilTween = trm.DOLocalMoveX(targetX, recoilDuration).SetLoops(2, LoopType.Yoyo);
        }

        public override void FinishFeedback()
        {
            if (_recoilTween != null && _recoilTween.IsActive())
            {
                _recoilTween.Kill();
                trm.localPosition = _initPos;
            }
        }
    }
}

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

        private Vector2 _initPos;
        private Tween _recoilTween;

        private void Awake()
        {
            _initPos = trm.localPosition;
        }

        public override void CreateFeedback()
        {
            float targetX = KimMet.GetWorldMousePos().x > trm.position.x ? recoilAmount : -recoilAmount;
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

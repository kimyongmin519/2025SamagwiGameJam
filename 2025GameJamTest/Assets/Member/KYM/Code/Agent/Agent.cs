using System;
using System.Collections;
using UnityEngine;

namespace Member.KYM.Code.Agent
{
    public abstract class Agent : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Material _hitMaterial;
        private Material _defaultMaterial;
        public HealthSystem HealthSystem { get; protected set; }

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            HealthSystem = GetComponent<HealthSystem>();
            
            _defaultMaterial = _spriteRenderer.material;
            
            if (_hitMaterial == null)
                _hitMaterial = Resources.Load<Material>("Materials/HitMat");

            HealthSystem.OnDamaged += HitShader;
        }

        private void HitShader()
        {
            StartCoroutine(HitShaderCor());
        }

        private IEnumerator HitShaderCor()
        {
            _spriteRenderer.material = _hitMaterial;
            yield return new WaitForSeconds(0.05f);
            _spriteRenderer.material = _defaultMaterial;
        }

        private void OnDestroy()
        {
            HealthSystem.OnDamaged -= HitShader;
        }
    }
}
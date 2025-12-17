using System;
using Member.KYM._02.Scripts.SO;
using UnityEngine;
using UnityEngine.Events;

namespace Member.KYM._02.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerDataSO playerData;
        [field:SerializeField] public PlayerInputSO PlayerInputData { get; private set; }
        public AgentMovement MoveCompo {get; private set; }
        public UnityEvent<Vector2,Transform> OnPointerChanged;

        private void Awake()
        {
            MoveCompo = GetComponent<AgentMovement>();
        }

        private void Update()
        {
            MoveCompo.SetSpeed(Vector2.Distance(PlayerInputData.MousePos, transform.position) * playerData.CorrectionSpeed);
            
            LookAtKim();
            
            //OnPointerChanged?.Invoke(PlayerInputData.MousePos, transform);
        }

        private void FixedUpdate()
        {
            MoveCompo.SetMoveDir(GetMouseDir());
        }

        private void LookAtKim()
        {
            Vector2 dir = GetMouseDir();
            
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        }
        private Vector2 GetMouseDir()
        {
            return (PlayerInputData.MousePos - (Vector2)transform.position).normalized;;
        }
    }
}

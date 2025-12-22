using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code.Players
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "KimSO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, Controller.IPlayerActions
    {
        private Controller _controller;

        public Vector2 MoveDir { get; private set; }
        public Vector2 MousePos { get;private set; }
        public event Action OnAttackPressed;
        public event Action OnAttackReleased;
        public event Action OnJumpPressed;

        private void OnEnable()
        {
            if (_controller == null)
                _controller = new Controller();
            
            _controller.Player.SetCallbacks(this);
            _controller.Player.Enable();
        }

        private void OnDisable()
        {
            _controller.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
                MoveDir = context.ReadValue<Vector2>();
            if (context.canceled)
                MoveDir = Vector2.zero;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnJumpPressed?.Invoke();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnAttackPressed?.Invoke();
            else
                OnAttackReleased?.Invoke();
        }

        public void OnMousePos(InputAction.CallbackContext context)
        {
            MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }
    }
}

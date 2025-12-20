using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code.SO
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "KimSO/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, Controller.IPlayerActions
    {
        private Controller _controller;

        public Vector2 MousePos { get;private set; }
        public event Action OnMouseInput;

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

        public void OnMousePos(InputAction.CallbackContext context)
        {
            MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }

        public void OnNewaction(InputAction.CallbackContext context)
        {
            
        }
    }
}

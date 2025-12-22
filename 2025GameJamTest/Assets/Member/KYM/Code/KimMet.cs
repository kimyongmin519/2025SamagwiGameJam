using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code
{
    public static class KimMet
    {
        public static Vector2 GetWorldMousePos()
        {
            return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
    }
}

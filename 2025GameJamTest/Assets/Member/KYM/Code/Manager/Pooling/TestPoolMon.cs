using System;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Member.KYM.Code.Manager.Pooling
{
    public class TestPoolMon : MonoBehaviour,IPoolable
    {

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                EventBus<ActiveUIEvent>.Raise(new ActiveUIEvent(Color.blue));
            }
        }

        public string ItemName { get; }
        
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Reset()
        {
            
        }
    }
}

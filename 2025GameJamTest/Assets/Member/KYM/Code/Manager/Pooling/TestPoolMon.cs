using Member.KYM._02.Scripts.Interface;
using UnityEngine;

namespace Member.KYM._02.Scripts.Manager.Pooling
{
    public class TestPoolMon : MonoBehaviour,IPoolable
    {
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

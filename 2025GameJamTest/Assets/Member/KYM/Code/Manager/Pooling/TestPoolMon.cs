using Member.KYM.Code.Interface;
using UnityEngine;

namespace Member.KYM.Code.Manager.Pooling
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

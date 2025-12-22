using Member.KYM.Code.Interface;
using UnityEngine;

namespace Member.SYW._01_Scripts.ETC
{
    public class HatsuneMikuLoveBeam : MonoBehaviour, IPoolable
    {
        public string ItemName => gameObject.name;
        
        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void Reset()
        {  
            
        }
    }
}
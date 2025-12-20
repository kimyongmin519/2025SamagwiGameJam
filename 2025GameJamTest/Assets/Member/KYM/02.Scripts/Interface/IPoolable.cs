using UnityEngine;

namespace Member.KYM._02.Scripts.Interface
{
    public interface IPoolable
    {
        public string ItemName { get; }

        public GameObject GetGameObject();

        public void Reset();
    }
}

using UnityEngine;

namespace Member.KYM.Code.Interface
{
    public interface IPoolable
    {
        public string ItemName { get; }

        public GameObject GetGameObject();

        public void Reset();
    }
}

using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.KYM.Code.Manager
{
    public class UpgradeManager : MonoSingleton<UpgradeManager>
    {
        public int UpgradePoint {get; private set;}
        private void Start()
        {
            PlayerPrefs.SetInt("UpgradePoint", UpgradePoint);
        }

        public void PlusPoint(int amount)
        {
            UpgradePoint += amount;
            PlayerPrefs.SetInt("UpgradePoint", UpgradePoint);
        }
    }
}

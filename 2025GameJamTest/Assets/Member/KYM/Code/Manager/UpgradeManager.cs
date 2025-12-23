using Member.SYW._01_Scripts.Manager;
using UnityEngine;

namespace Member.KYM.Code.Manager
{
    public class UpgradeManager : MonoSingleton<UpgradeManager>
    {
        public int UpgradePoint {get; private set;}
        private void Start()
        {
            UpgradePoint = PlayerPrefs.GetInt("UpgradePoint");
        }

        public void PlusPoint(int amount)
        {
            UpgradePoint = PlayerPrefs.GetInt("UpgradePoint");
            UpgradePoint += amount;
            PlayerPrefs.SetInt("UpgradePoint", UpgradePoint);
            PlayerPrefs.Save();
        }
    }
}

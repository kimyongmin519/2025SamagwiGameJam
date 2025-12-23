using Member.KYM.Code.Bus;
using Member.KYM.Code.Manager.Level;

namespace Member.KYM.Code.GameEvents
{
    public struct WeaponUpgradeEvent : IEvent
    {
        public UpgradeType upgradeType;

        public WeaponUpgradeEvent(UpgradeType _type)
        {
            upgradeType = _type;
        }
    }
}
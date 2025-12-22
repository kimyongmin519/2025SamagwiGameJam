using Member.KYM.Code.Bus;

namespace Member.KYM.Code.GameEvents
{
    public struct AmmoReturnEvent : IEvent
    {
        public int Ammo { get; private set; }

        public void AmmoReturn(int ammo)
        {
            Ammo = ammo;
        }
    }
}
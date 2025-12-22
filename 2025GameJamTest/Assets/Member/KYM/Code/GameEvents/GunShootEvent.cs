using System;
using Member.KYM.Code.Bus;

namespace Member.KYM.Code.GameEvents
{
    public struct GunShootEvent : IEvent
    {
        public Action ShootEvent;
        
        public GunShootEvent(Action action)
        {
            ShootEvent = action;
        }
    }
}
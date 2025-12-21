using UnityEngine;
using Member.KYM.Code.Bus;

namespace Member.KYM.Code.GameEvents
{
    public struct ActiveUIEvent : IEvent
    {
        public Color Color { get; private set; }

        public ActiveUIEvent(Color color)
        {
            Color = color;
        }
    }
}
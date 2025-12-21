namespace Member.KYM.Code.Bus
{
    public static class EventBus
    {
        public delegate void Event(GameEvent evt);

        public static event Event OnEvent;
        public static void Raise(GameEvent evt) => OnEvent?.Invoke(evt);
    }
}
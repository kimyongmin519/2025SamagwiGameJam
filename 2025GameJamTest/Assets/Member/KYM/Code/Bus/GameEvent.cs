using Member.KYM.Code.Players;

namespace Member.KYM.Code.Bus
{
    public struct GameEvent
    {
        public Player Player { get; }

        public GameEvent(Player player)
        {
            Player = player;
        }
    }
}
using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class KillOrSpawnCommandArgs : ICommandArgs
    {
        public readonly List<IUnit> Army;
        public readonly IUnit Creature;
        public readonly int Position;
        public readonly IUnit Dealer;

        public KillOrSpawnCommandArgs(List<IUnit> army, IUnit creature, int position, IUnit dealer)
        {
            Army = army;
            Creature = creature;
            Position = position;
            Dealer = dealer;
        }
    }
}
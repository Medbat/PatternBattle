using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class EquipOrUnEquipKnightCommandArgs : ICommandArgs
    {
        public readonly List<IUnit> Army;
        public readonly int KnightPosition;
        public readonly IUnit Dealer;

        public EquipOrUnEquipKnightCommandArgs(List<IUnit> army, int knightPosition, IUnit dealer)
        {
            Army = army;
            KnightPosition = knightPosition;
            Dealer = dealer;
        }
    }
}
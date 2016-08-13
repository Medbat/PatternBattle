using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class DamageOrHealCommandArgs : ICommandArgs
    {
        public readonly IUnit Aim;
        public readonly double Points;
        public readonly IUnit Dealer;
        public readonly bool IsSpecialAction;

        public DamageOrHealCommandArgs(IUnit aim, double points, IUnit dealer, bool isSpecialAction)
        {
            Aim = aim;
            Points = points;
            Dealer = dealer;
            IsSpecialAction = isSpecialAction;
        }
    }
}
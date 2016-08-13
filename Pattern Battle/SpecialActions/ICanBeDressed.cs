using Pattern_Battle.Units;

namespace Pattern_Battle.SpecialActions
{
    interface ICanBeDressed
    {
        Knight Wear(ref int ammNum);
        Knight Unwear(ref int ammNum);
    }
}

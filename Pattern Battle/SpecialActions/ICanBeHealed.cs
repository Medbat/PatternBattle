using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.SpecialActions
{
    interface ICanBeHealed
    {
        int MaxHealth { get; set; }
        void Heal(int hitPoints, IUnit healer);
    }
}

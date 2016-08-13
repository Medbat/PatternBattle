using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Units
{
    public class HeavyInfantryman : HeavyUnit, ICanBeHealed
    {
        public int MaxHealth { get; set; }

        public HeavyInfantryman()
        {
            Name = "HeavyInfantryman";
            AttackPower = 16;
            Defence = 3;
            HitPoints = MaxHealth = 40;
        }

        public void Heal(int hitPoints, IUnit healer)
        {
            var heal = (int) (HitPoints + hitPoints > MaxHealth ? MaxHealth - HitPoints : hitPoints);
            Consts.Invoker.Invoke(CommandType.Heal, new DamageOrHealCommandArgs(this, heal, healer, true));
        }
    }
}

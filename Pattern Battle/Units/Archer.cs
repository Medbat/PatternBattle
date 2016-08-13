using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Units
{
    public class Archer : LightUnit, ISpecialAction
    {
        public Archer()
        {
            Name = "Archer";
            AttackPower = 8;
            Defence = 1;
            HitPoints = 15;
            SpecialActionPower = 14;
            SpecialActionRange = 5;
        }

        public int SpecialActionPower { get; set; }
        public int SpecialActionRange { get; set; }

        public void SpecialAction(List<IUnit> units)
        {
            var avaliableAims = units.Where(unit => unit.PlayerId != PlayerId).ToList();
            if (!avaliableAims.Any())
                return;
            var aim = avaliableAims[Consts.Rand.Next(0, avaliableAims.Count())];
            var damage = -(aim.Defence - SpecialActionPower*(Consts.Rand.Next(11)/10.0));
            if (damage < 0)
                damage = 0;
            else
            {
                Consts.DeadLock = false;
            }
            Consts.Invoker.Invoke(CommandType.Damage, new DamageOrHealCommandArgs(aim, damage, this, true));
            //aim.HitPoints -= damage > 0 ? damage : 0;
        }
    }
}

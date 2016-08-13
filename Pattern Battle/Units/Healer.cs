using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Units
{
    public class Healer : LightUnit, ISpecialAction
    {
        public int SpecialActionPower { get; set; }
        public int SpecialActionRange { get; set; }

        public Healer()
        {
            Name = "Healer";
            AttackPower = 10;
            Defence = 3;
            HitPoints = 30;
            SpecialActionPower = 6;
            SpecialActionRange = 3;
        }

        public void SpecialAction(List<IUnit> units)
        {
            var avaliableAims = units.Where(unit => unit.PlayerId == PlayerId).OfType<ICanBeHealed>().ToList();
            if (!avaliableAims.Any())
                return;
            foreach (var avaliableAim in avaliableAims)
            {
                if (!((avaliableAim as IUnit).HitPoints < avaliableAim.MaxHealth)) continue;
                Consts.Invoker.Invoke(CommandType.Heal, new DamageOrHealCommandArgs(avaliableAim as IUnit, 
                    SpecialActionPower, this, true));
                return;
            }
        }
    }
}

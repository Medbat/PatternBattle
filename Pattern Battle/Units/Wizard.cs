using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Units
{
    public class Wizard : LightUnit, ISpecialAction
    {
        public Wizard()
        {
            Name = "Wizard";
            AttackPower = 10;
            Defence = 2;
            HitPoints = 28;
            SpecialActionPower = 5;
            SpecialActionRange = 3;
        }

        public int SpecialActionPower { get; set; }
        public int SpecialActionRange { get; set; }

        public void SpecialAction(List<IUnit> units)
        {
            var avaliableAims = units.Where(unit => unit.PlayerId == PlayerId).OfType<IClonable>().ToList();
            if (!avaliableAims.Any())
                return;
            if (Consts.Rand.NextDouble()*100 <= SpecialActionPower)
            {
                Consts.Invoker.Invoke(CommandType.Resurrect, 
                    new KillOrSpawnCommandArgs(Consts.SevenNationArmies[PlayerId],
                        avaliableAims[Consts.Rand.Next(0, avaliableAims.Count())].Clone(),
                            Consts.SevenNationArmies[PlayerId].FindIndex(wiz => ReferenceEquals(this, wiz)) + 1, this));
            }   
        }
    }
}

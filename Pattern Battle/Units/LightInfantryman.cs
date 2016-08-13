using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Units
{
    public class LightInfantryman : LightUnit, IClonable, ISpecialAction
    {
        public int SpecialActionPower { get; set; }
        public int SpecialActionRange { get; set; }

        public LightInfantryman()
        {
            Name = "LightInfantryman";
            AttackPower = 10;
            Defence = 2;
            HitPoints = 20;
            SpecialActionRange = 1;

        }

        public IUnit Clone()
        {
            return MemberwiseClone() as LightInfantryman;
        }

        public void SpecialAction(List<IUnit> units)
        {
            var avaliableAims = units.Where(unit => unit.PlayerId == PlayerId).OfType<ICanBeDressed>().ToList();
            avaliableAims.RemoveAll(kn => !((Knight)kn).CanBeDressed());
            if (!avaliableAims.Any())
                return;
            
            var knight = avaliableAims[Consts.Rand.Next(avaliableAims.Count())];
            Consts.Invoker.Invoke(CommandType.EquipKnight, 
                new EquipOrUnEquipKnightCommandArgs(Consts.SevenNationArmies[PlayerId],
                    Consts.SevenNationArmies[PlayerId].FindIndex(kn => ReferenceEquals(knight, kn)), this));
        }

    }
}

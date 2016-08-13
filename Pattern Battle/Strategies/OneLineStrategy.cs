using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Strategies
{
    public class OneLineStrategy : IStrategy
    {
        public IEnumerable<IUnit[]> EnumeratePairs()
        {
            return new List<IUnit[]>(1) {new[] {Consts.SevenNationArmies[0][0], Consts.SevenNationArmies[1][0]}};
        }

        public IEnumerable<ISpecialAction> EnumerateSpecialActionDealers()
        {
            List<IUnit>[] specialists = 
            {
                Consts.SevenNationArmies[0].FindAll(unit => unit is ISpecialAction && 
                    !EnumeratePairs().Any(pair => pair.Any(unit1 => ReferenceEquals(unit, unit1)))),
                Consts.SevenNationArmies[1].FindAll(unit => unit is ISpecialAction &&
                    !EnumeratePairs().Any(pair => pair.Any(unit1 => ReferenceEquals(unit, unit1))))
            };
            var i = 0;
            var j = 0;
            while (true)
            {
                if (i >= specialists[0].Count && j >= specialists[1].Count)
                    break;
                if (i < specialists[0].Count)
                    yield return specialists[0][i++] as ISpecialAction;
                if (j < specialists[1].Count)
                    yield return specialists[1][j++] as ISpecialAction;
            }
        }

        public IEnumerable<IUnit> GetUnitsInRange(ISpecialAction unit)
        {
            var line = new List<IUnit>(Consts.SevenNationArmies[1]);
            line.Reverse();
            line = line.Union(Consts.SevenNationArmies[0]).ToList();
            var index = line.FindIndex(u => ReferenceEquals(u, unit));
            for (var i = index - unit.SpecialActionRange >= 0 ? index - unit.SpecialActionRange : 0; 
                i < (index + unit.SpecialActionRange < line.Count ? index + unit.SpecialActionRange + 1 : line.Count - 1); 
                i++)
            {
                yield return line[i];
            }
        }

        public void CheckDeadLock()
        {
            Consts.DeadLock = true;
            for (var i = 0; i < 1; i++)
                if (Consts.SevenNationArmies[0][i].AttackPower > Consts.SevenNationArmies[1][i].Defence ||
                    Consts.SevenNationArmies[1][i].AttackPower > Consts.SevenNationArmies[0][i].Defence)
                {
                    Consts.DeadLock = false;
                }
        }
    }
}

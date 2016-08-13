using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Strategies
{
    public class MaxLinesStrategy : IStrategy
    {
        public IEnumerable<IUnit[]> EnumeratePairs()
        {
            for (int i = 0;
                i <
                (Consts.SevenNationArmies[0].Count() > Consts.SevenNationArmies[1].Count()
                    ? Consts.SevenNationArmies[1].Count()
                    : Consts.SevenNationArmies[0].Count());
                i++)
            {
                yield return new[] {Consts.SevenNationArmies[0][i], Consts.SevenNationArmies[1][i]};
        }
        }

        public IEnumerable<ISpecialAction> EnumerateSpecialActionDealers()
        {
            var maxListIndex = (Consts.SevenNationArmies[0].Count() < Consts.SevenNationArmies[1].Count()
                ? 1
                : 0);
            for (var i = Consts.SevenNationArmies[1 - maxListIndex].Count();
                i < Consts.SevenNationArmies[maxListIndex].Count();
                i++)
            {
                var action = Consts.SevenNationArmies[maxListIndex][i] as ISpecialAction;
                if (action != null)
                    yield return action;
            }
        }

        public IEnumerable<IUnit> GetUnitsInRange(ISpecialAction unit)
        {
            var index =
                Consts.SevenNationArmies[
                    ((Consts.SevenNationArmies[0].Find(u => ReferenceEquals(u, unit)) != null) ? 0 : 1)].FindIndex(
                        u => ReferenceEquals(u, unit));
            for (var i = index - unit.SpecialActionRange >= 0 ? index - unit.SpecialActionRange : 0;
                i < (unit.SpecialActionRange == 0 ? 0 : index + unit.SpecialActionRange + 1);
                i++)
            {
                if (Consts.SevenNationArmies[0].Count > i)
                    yield return Consts.SevenNationArmies[0][i];
                if (Consts.SevenNationArmies[1].Count > i)
                    yield return Consts.SevenNationArmies[1][i];
            }

        }

        public void CheckDeadLock()
        {
            Consts.DeadLock = true;
            for (var i = 0; i < (Consts.SevenNationArmies[0].Count < Consts.SevenNationArmies[1].Count
                ? Consts.SevenNationArmies[0].Count
                : Consts.SevenNationArmies[1].Count); i++)
                if (Consts.SevenNationArmies[0][i].AttackPower > Consts.SevenNationArmies[1][i].Defence ||
                    Consts.SevenNationArmies[1][i].AttackPower > Consts.SevenNationArmies[0][i].Defence)
                {
                    Consts.DeadLock = false;
                }
        }
    }
}

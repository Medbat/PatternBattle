using System.Collections.Generic;
using System.Linq;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Strategies
{
    public class ThreeLinesStrategy : IStrategy
    {
        public IEnumerable<IUnit[]> EnumeratePairs()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Consts.SevenNationArmies[0].Count > i && Consts.SevenNationArmies[1].Count > i)
                    yield return new[] {Consts.SevenNationArmies[0][i], Consts.SevenNationArmies[1][i]};
            }
        }

        public IEnumerable<ISpecialAction> EnumerateSpecialActionDealers()
        {
            for (int i = 6; i < 9; i++)
            {
                if (Consts.SevenNationArmies[0].Count > i)
                {
                    var action = Consts.SevenNationArmies[0][i] as ISpecialAction;
                    if (action != null)
                        yield return action;
                }
                if (Consts.SevenNationArmies[1].Count > i)
                {
                    var action = Consts.SevenNationArmies[1][i] as ISpecialAction;
                    if (action != null)
                        yield return action;
                }
            }
        }

        public IEnumerable<IUnit> GetUnitsInRange(ISpecialAction unit)
        {
            var line = Consts.SevenNationArmies[
                ((Consts.SevenNationArmies[0].Find(u => ReferenceEquals(u, unit)) != null) ? 0 : 1)];
            int realIndex = line.FindIndex(u => ReferenceEquals(u, unit));
            if (unit.SpecialActionRange == 1)
            {
                for (int i = line.Count > 3 ? 3 : line.Count; i < (line.Count > 11 ? 11 : line.Count); i++)
                    if (
                        (realIndex != 6 || i != realIndex - 1 && i != realIndex + 2 && i != realIndex + 5) &&
                        (realIndex != 8 || i != realIndex - 5 && i != realIndex - 2 && i != realIndex + 1))
                        yield return line[i];
            }
            else
            {
                line =
                    Consts.SevenNationArmies[0].ToArray().Reverse().ToList().Union(Consts.SevenNationArmies[1]).ToList();
                var index = line.FindIndex(u => ReferenceEquals(u, unit));
                for (var i = (index/3)*3 - unit.SpecialActionRange*3 >= 0 ? (index/3)*3 - unit.SpecialActionRange*3 : 0;
                    i <
                    (unit.SpecialActionRange > 0
                        ? ((index/3)*3 + 3 + unit.SpecialActionRange*3 < line.Count
                            ? index/3*3 + 3 + unit.SpecialActionRange*3
                            : line.Count)
                        : 0);
                    i++)
                {
                    yield return line[i];
                }
            }
        }
        public void CheckDeadLock()
        {
            Consts.DeadLock = true;
            var count = Consts.SevenNationArmies[0].Count < Consts.SevenNationArmies[1].Count
                ? Consts.SevenNationArmies[0].Count
                : Consts.SevenNationArmies[1].Count;
            if (count > 3)
                count = 3;
            for (var i = 0; i < count; i++)
                if (Consts.SevenNationArmies[0][i].AttackPower > Consts.SevenNationArmies[1][i].Defence ||
                    Consts.SevenNationArmies[1][i].AttackPower > Consts.SevenNationArmies[0][i].Defence)
                {
                    Consts.DeadLock = false;
                }
        }
    }
}

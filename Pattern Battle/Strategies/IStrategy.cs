using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.SpecialActions;

namespace Pattern_Battle.Strategies
{
    public interface IStrategy
    {
        IEnumerable<IUnit[]> EnumeratePairs();
        IEnumerable<ISpecialAction> EnumerateSpecialActionDealers();
        IEnumerable<IUnit> GetUnitsInRange(ISpecialAction unit);
        void CheckDeadLock();
    }
}

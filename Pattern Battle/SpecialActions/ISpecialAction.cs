using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.SpecialActions
{
    public interface ISpecialAction
    {
        void SpecialAction(List<IUnit> units);
        int SpecialActionPower { get; set; }
        int SpecialActionRange { get; set; }
    }
}

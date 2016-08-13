using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Units
{
    public class UnitComparer : IEqualityComparer<IUnit>, IComparer<IUnit>
    {
        public bool Equals(IUnit x, IUnit y)
        {
            return string.CompareOrdinal(x.Name, y.Name) == 0;
        }

        public int GetHashCode(IUnit obj)
        {
            if (ReferenceEquals(obj, null)) return 0;
            var hashName = obj.Name?.GetHashCode() ?? 0;
            return hashName;
        }

        public int Compare(IUnit x, IUnit y)
        {
            return string.CompareOrdinal(x.Name, y.Name);
        }
    }
}

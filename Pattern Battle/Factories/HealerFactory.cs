
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Factories
{
    public class HealerFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new Healer();
        }
    }
}

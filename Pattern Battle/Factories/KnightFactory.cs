using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Factories
{
    class KnightFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new Knight();
        }
    }
}

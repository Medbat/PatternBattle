using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Factories
{
    class GulyayGorodFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new GulyayGorod();
        }
    }
}

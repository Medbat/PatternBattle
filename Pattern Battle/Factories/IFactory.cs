using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Factories
{
    public interface IFactory
    {
        IUnit CreateUnit();
    }
}

using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Factories
{
    public class WizardFactory : IFactory
    {
        public IUnit CreateUnit()
        {
            return new Wizard();
        }
    }
}

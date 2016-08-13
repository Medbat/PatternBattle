using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Units
{
    public class GulyayGorod : HeavyUnit
    {
        private readonly SpecialUnits.GulyayGorod _instance;
        private double _hp;
        public override double HitPoints
        {
            get { return _instance.AreDeath?_hp:0; }
            set
            {
                if (_instance.AreDeath && _hp - value > 0)
                    _instance.TakeDamage((int) (_hp - value));
                _hp = value;

            }
        }

        public override double AttackPower => _instance.GetStrength();

        public GulyayGorod()
        {
            Name = "GulyayGorod";
            _instance = new SpecialUnits.GulyayGorod(55, 5, Consts.GulyayGorodPrice);
            _hp = _instance.GetHealth();
        }
    }
}

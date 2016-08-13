namespace Pattern_Battle.Units.KnightDecorator
{
    class KnightHorse : KnightAmmunition
    {
        public override string ToString()
        {
            return Name;
        }
        public override string Name
        {
            get { return _knight == null ? _name : _knight.Name + " with horse"; }
            set
            {
                _name = value;
                if (_knight != null)
                    _knight.Name = value;
            }
        }

        public override double Defence { get { return base.Defence + 2; } }
        public override double AttackPower { get { return base.AttackPower + 2; } }
    }
}

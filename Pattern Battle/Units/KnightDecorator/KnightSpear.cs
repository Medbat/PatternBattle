namespace Pattern_Battle.Units.KnightDecorator
{
    class KnightSpear : KnightAmmunition
    {
        public override string ToString()
        {
            return Name;
        }
        public override string Name
        {
            get { return _knight == null ? _name : _knight.Name + " with spear"; }
            set
            {
                _name = value;
                if (_knight != null)
                    _knight.Name = value;
            }
        }

        public override double AttackPower { get { return base.AttackPower + 4; } }
    }
}

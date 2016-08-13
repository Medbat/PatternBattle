using System.Collections.Generic;
using Pattern_Battle.Command;

namespace Pattern_Battle.Units.KnightDecorator
{
    public abstract class KnightAmmunition : Knight
    {
        public new List<KnightAmmunitionEnum> Ammunition { get; set; }

        public override double AttackPower => _knight != null ? _knight.AttackPower : _attackPower;
        public override double Defence => _knight != null ? _knight.Defence : _defence;

        public Knight AddAmmunition(Knight knight)
        {
            this._knight = knight;
            return this;
        }

        public Knight DeleteAmmunition()
        {
            return _knight;
            // Consts.UnWearKnight(ref knight) { knight = knight.DeleteAmmunition(); }
        }

    }
}

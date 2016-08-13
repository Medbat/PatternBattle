using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.SpecialActions;
using Pattern_Battle.Units.KnightDecorator;

namespace Pattern_Battle.Units
{
    public class Knight : HeavyUnit, ICanBeDressed
    {
        protected bool IsInserted = false;
        // ReSharper disable once InconsistentNaming
        protected Knight _knight;
        // ReSharper disable once InconsistentNaming

	    public virtual List<KnightAmmunitionEnum> Ammunition { get; set; }

	    private double _hp;
        protected double _attackPower;
        protected double _defence;
        protected string _name;
        public override string Name
        {
            get { return _knight == null ? _name : _knight.Name; }
            set
            {
                _name = value;
                if (_knight != null)
                    _knight.Name = value;
            }
        }

	    public double SafeHpChanging
	    {
		    get { return HitPoints; }
			set { _hp = value; }
	    }

        public override double HitPoints
        {
            get { return _knight != null ? _knight.HitPoints : _hp; }
            set
            {
                {
                    if (HitPoints != 0 && value < HitPoints)
                        if (!IsInserted)
                            if (Ammunition.Count > 0 && Consts.Rand.NextDouble() * 100 <= 30)
                                Consts.Invoker.Invoke(CommandType.UnEquipKnight,
                                    new EquipOrUnEquipKnightCommandArgs(Consts.SevenNationArmies[PlayerId],
                                        Consts.SevenNationArmies[PlayerId].FindIndex(u => ReferenceEquals(this, u)),
                                        null));
                    if (_knight != null)
                        _knight.HitPoints = value;
                    else
                        _hp = value;
                }
            }
        }

        public override double AttackPower
        {
            get { return _attackPower; }
            set { _attackPower = value; }
        }

        public override double Defence
        {
            get { return _defence; }
            set { _defence = value; }
        }

        public Knight()
        {
            Name = "Knight";
            _attackPower = 20;
            _defence = 3;
            _hp = 60;
            Ammunition = new List<KnightAmmunitionEnum>(5);
        }

        public Knight Wear(int amm)
        {
            int t = amm;
            return Wear(ref t);
        }

        public Knight Wear(ref int ammunitionNumber)
        {
            if (Ammunition.Count == 5)
                return this;

            KnightAmmunition ka;
            var knightAmmunitionList = new List<KnightAmmunitionEnum>();
            for (var i = 0; i < 5; i++)
            {
                var i1 = i;
                if (Ammunition.FindAll(l => l == (KnightAmmunitionEnum) i1).Count == 0)
                    knightAmmunitionList.Add((KnightAmmunitionEnum) i1);
            }

            var switcher = 
                ammunitionNumber == -1 ?
                knightAmmunitionList[Consts.Rand.Next(knightAmmunitionList.Count)] :
                (KnightAmmunitionEnum)ammunitionNumber;
            ammunitionNumber = (int) switcher;
            var newKnight = new Knight();
            switch (switcher)
            {
                case KnightAmmunitionEnum.Helmet:
                    ka = new KnightHelmet();
                    newKnight = ka.AddAmmunition(this);
                    newKnight.Ammunition.AddRange(Ammunition);
                    newKnight.Ammunition.Add(KnightAmmunitionEnum.Helmet);
                    break;
                case KnightAmmunitionEnum.Horse:
                    ka = new KnightHorse();
                    newKnight = ka.AddAmmunition(this);
                    newKnight.Ammunition.AddRange(Ammunition);
                    newKnight.Ammunition.Add(KnightAmmunitionEnum.Horse);
                    break;
                case KnightAmmunitionEnum.Armor:
                    ka = new KnightArmor();
                    newKnight = ka.AddAmmunition(this);
                    newKnight.Ammunition.AddRange(Ammunition);
                    newKnight.Ammunition.Add(KnightAmmunitionEnum.Armor);
                    break;
                case KnightAmmunitionEnum.Shield:
                    ka = new KnightShield();
                    newKnight = ka.AddAmmunition(this);
                    newKnight.Ammunition.AddRange(Ammunition);
                    newKnight.Ammunition.Add(KnightAmmunitionEnum.Shield);
                    break;
                default:
                    ka = new KnightSpear();
                    newKnight = ka.AddAmmunition(this);
                    newKnight.Ammunition.AddRange(Ammunition);
                    newKnight.Ammunition.Add(KnightAmmunitionEnum.Spear);
                    break;
            }
            newKnight.PlayerId = PlayerId;
            newKnight.UnitId = UnitId;
            IsInserted = true;
            return newKnight;
        }

        public Knight Unwear(int ammNum)
        {
            int t = ammNum;
            return Unwear(ref t);
        }

        public Knight Unwear(ref int ammunitionNumber)
        {
            if (Ammunition.Count == 0)
                return this;
            if (Ammunition.Count == 1)
            {
                Ammunition.RemoveAt(0);
                return _knight;
            }
            int toRemoveIndex = ammunitionNumber == - 1 ? Consts.Rand.Next(Ammunition.Count) : -1;
            var kn = this;
            int number = ammunitionNumber;
            if (toRemoveIndex == -1)
            {
                while (kn.Ammunition.FindAll(t => t == ((KnightAmmunitionEnum) number)).Count != 0)
                {
                    kn = kn._knight;
                    toRemoveIndex++;
                }
            }
            else
            {
                ammunitionNumber = (int) Ammunition[Ammunition.Count - toRemoveIndex - 1];
                number = ammunitionNumber;
            }
            if (toRemoveIndex == 0)
            {
                return _knight;
            }
            Ammunition.RemoveAll(t => t == (KnightAmmunitionEnum)number);
            Knight beforeRemovable = this;
            for (int i = 0; i < toRemoveIndex - 1; i++)
            {
                beforeRemovable = beforeRemovable._knight;
                beforeRemovable.Ammunition.RemoveAll(t => t == (KnightAmmunitionEnum) number);
            }
            if (beforeRemovable._knight != null)
            {
                beforeRemovable._knight = beforeRemovable._knight._knight;
            }
            IsInserted = false;
            return this;
        }

        public bool CanBeDressed()
        {
            return Ammunition.Count != 5;
        }
    }
}

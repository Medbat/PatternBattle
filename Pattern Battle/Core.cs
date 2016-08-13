using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.Factories;
using Pattern_Battle.Units;

namespace Pattern_Battle
{
    internal struct UnitAndPriceElem
    {
        public readonly IFactory Factory;
        public readonly int Price;

        public UnitAndPriceElem(IFactory factory, int price)
        {
            Factory = factory;
            Price = price;
        }
    }

    internal class ElemPriceComparer : IComparer<UnitAndPriceElem>
    {
        public int Compare(UnitAndPriceElem x, UnitAndPriceElem y)
        {
            if (x.Price == y.Price)
                return 0;
            if (x.Price < y.Price)
                return -1;
            return 1;
        }
    }

    public static class Core
    {
        private static readonly List<UnitAndPriceElem> UnitFactory;

        public static bool IsBattleOver => !(Consts.SevenNationArmies[0].Any() && Consts.SevenNationArmies[1].Any() || Consts.DeadLock);

        static Core()
        {
            UnitFactory = new List<UnitAndPriceElem>
            {
                new UnitAndPriceElem(new LightInfantrymanFactory(), 100),
				new UnitAndPriceElem(new HeavyInfantrymanFactory(), 250),
				new UnitAndPriceElem(new ArcherFactory(), 300),
				new UnitAndPriceElem(new WizardFactory(), 370),
				new UnitAndPriceElem(new HealerFactory(), 400),
				new UnitAndPriceElem(new KnightFactory(), 500),
				new UnitAndPriceElem(new GulyayGorodFactory(), Consts.GulyayGorodPrice)
            };
            UnitFactory.Sort(new ElemPriceComparer());
            Console.WriteLine();
        }
        //+
        public static void CreateRandomArmies()
        {
            var id = 0;
            Consts.SevenNationArmies[0] = CreateRandomArmy(0, ref id, Consts.TotalPrice);
            Consts.SevenNationArmies[1] = CreateRandomArmy(1, ref id, Consts.TotalPrice);
            SetIds();
        }
        //+
        private static List<IUnit> CreateRandomArmy(int playerId, ref int startUnitId, int totalPrice)
        {
            var units = new List<IUnit>();
            var priceList = new List<int>();
            for (var i = 0; i < UnitFactory.Count(); i++)
            {
                if (priceList.FindAll(price => price == UnitFactory[i].Price).Count == 0)
                    priceList.Add(UnitFactory[i].Price);
            }
            var chances = new List<int>(priceList);
            for (var i = 0; i < chances.Count; i++)
            {
                chances[i] = Consts.TotalPrice/priceList[i];
            }

            while (totalPrice >= priceList.Min())
            {
                int a;
                for (a = 0; a < priceList.Count && priceList[a] <= totalPrice; a++) { }
                if (a < priceList.Count)
                {
                    priceList.RemoveRange(a, priceList.Count - a);
                    chances.RemoveRange(a, chances.Count - a);
                }
                var maxPrice = priceList.Max();
                var sum = chances.Sum();

                while (totalPrice >= maxPrice)
                {
                    var rand = Consts.Rand.Next(sum);
                    var j = -1;
                    do
                    {
                        j++;
                        rand -= chances[j];
                    } while (rand > 0);

                    var index = Consts.Rand.Next(UnitFactory.FindAll(el => el.Price == priceList[j]).Count)
                                + UnitFactory.FindIndex(el => el.Price == priceList[j]);

                    units.Add(UnitFactory[index].Factory.CreateUnit());
                    totalPrice -= UnitFactory[index].Price;
                }
            }
            return units;
        }

        public static void SetIds()
        {
            int id = 0;
            for (int i = 0; i < 2; i++)
            {
                foreach (var unit in Consts.SevenNationArmies[i])
                {
                    unit.PlayerId = i;
                    unit.UnitId = id++;
                }
            }
        }

        public static bool TryBattleTick()
        {
            if (IsBattleOver)
                return false;
            Consts.Strategy.CheckDeadLock();
            foreach (var pair in Consts.Strategy.EnumeratePairs())
            {
                var turn = Consts.Rand.Next(2);
                Hit(pair[turn], pair[1 - turn]);
                Hit(pair[1 - turn], pair[turn]);
            }
            foreach (var specialActionDealer in Consts.Strategy.EnumerateSpecialActionDealers())
            {
                specialActionDealer.SpecialAction(Consts.Strategy.GetUnitsInRange(specialActionDealer).ToList());
            }
            DeleteDead();
            Consts.Invoker.Invoke(CommandType.None);
            if (Consts.DeadLock)
            {
		        return false;
	        }
                Consts.DeadLock = false;
            return true;
        }

        public static string GetArmiesTextRepresentation()
        {
            var result = new StringBuilder();
            var comparer = new UnitComparer();
            for (var i = 0; i < 2; i++)
            {
                result.Append("Армия " + Consts.PlayerNames[i] + ":\r\n");
                var units = Consts.SevenNationArmies[i].ToList();
                foreach (var unit in units)
                    result.Append(unit.FullName + " [" + unit.HitPoints + "] \n");
                result.Append("\n");
                /*
                result.Append("Армия " + Consts.PlayerNames[i] + ":" + Environment.NewLine);
                var units = Consts.SevenNationArmies[i].Distinct(comparer).ToList();
                units.Sort(comparer);
                foreach (var unit in units)
                    result.Append(unit.Name + ": " + 
                                  Consts.SevenNationArmies[i].FindAll(p => p.Name == unit.Name).Count +
                                  Environment.NewLine);
                                  */
            }
            return result.ToString();
        }

        public static string GetBattleResult()
        {
            if (!Consts.SevenNationArmies[0].Any() && !Consts.SevenNationArmies[1].Any() || Consts.DeadLock)
                return "draw";
            if (!Consts.SevenNationArmies[0].Any())
                return Consts.PlayerNames[1] + " wins";
            return Consts.PlayerNames[0] + " wins";
        }
        //+
        public static void Battle()
        {
            while (!IsBattleOver)
            {
                TryBattleTick();
            }
        }
        //+
        private static void DeleteDead()
        {
            foreach (var sevenNationArmy in Consts.SevenNationArmies)
            {
                for (var i = 0; i < sevenNationArmy.Count; i++)
                {
                    if (!(sevenNationArmy[i].HitPoints <= 0)) continue;
                    var unit = sevenNationArmy[i];
                    Consts.Invoker.Invoke(CommandType.Kill, new KillOrSpawnCommandArgs(sevenNationArmy, unit,
                        Consts.SevenNationArmies[unit.PlayerId].FindIndex(u => ReferenceEquals(unit, u)), null));
                    i--;
                }
                //sevenNationArmy.RemoveAll(unit => unit.HitPoints <= 0);
            }
        }
        //+
        private static void Hit(IUnit unit1, IUnit unit2)
        {
            if (unit1.HitPoints <= 0)
                return;
            var damage = unit1.Hit() - unit2.Defence;
            if (damage < 0)
                damage = 0;
            Consts.Invoker.Invoke(CommandType.Damage, new DamageOrHealCommandArgs(unit2, damage, unit1, false));
        }

        
    }
}
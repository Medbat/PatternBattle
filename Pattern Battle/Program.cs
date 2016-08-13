
namespace Pattern_Battle
{
    static class Program
    {
        public static void Main()
        {
            /*Consts.SevenNationArmies[0] = new List<IUnit>
            {
                new Wizard { PlayerId = 0 },
                new LightInfantryman { PlayerId = 0, HitPoints = 2 }
            };
            var invo = new Invoker();
            invo.Invoke(CommandType.Resurrect, new KillOrSpawnCommandArgs(Consts.SevenNationArmies[0], 
                Consts.SevenNationArmies[0][1], 2));
            invo.Invoke(CommandType.None);
            invo.CtrlZ();
            invo.CtrlY();
            return;*/

            
            /*Consts.SevenNationArmies[0] = new List<IUnit>
            {
                new Knight { PlayerId = 0 },
                new Healer { PlayerId = 0 }
            };
            Consts.SevenNationArmies[1] = new List<IUnit> { new LightInfantryman { PlayerId = 1 } };
            var invo = new Invoker();
            invo.Invoke(CommandType.EquipKnight,
                new EquipOrUnEquipKnightCommandArgs(Consts.SevenNationArmies[0], 0));
            invo.Invoke(CommandType.None);
            Console.WriteLine(Consts.SevenNationArmies[0][0]);
            invo.Invoke(CommandType.EquipKnight,
                new EquipOrUnEquipKnightCommandArgs(Consts.SevenNationArmies[0], 0));
            invo.Invoke(CommandType.None);
            Console.WriteLine(Consts.SevenNationArmies[0][0]);

            invo.CtrlZ();
            Console.WriteLine(Consts.SevenNationArmies[0][0]);
            invo.CtrlZ();
            Console.WriteLine(Consts.SevenNationArmies[0][0]);
            invo.CtrlY();
            Console.WriteLine(Consts.SevenNationArmies[0][0]);*/
            
            /*var invo = new Invoker();
            invo.Invoke(CommandType.Damage, 
                new DamageOrHealCommandArgs(Consts.SevenNationArmies[0][0], Consts.SevenNationArmies[1][0].Hit()));
            invo.Invoke(CommandType.None);
            Console.WriteLine(Consts.SevenNationArmies[0][0].HitPoints);*/
            

            Core.CreateRandomArmies();
            Core.Battle();
        }
    }
}

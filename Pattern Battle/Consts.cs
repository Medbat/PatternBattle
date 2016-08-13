using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Command;
using Pattern_Battle.Observer;
using Pattern_Battle.Strategies;

namespace Pattern_Battle
{
    public static class Consts
    {
        public const int GulyayGorodPrice = 290;
        public static readonly Random Rand = new Random(DateTime.Now.Millisecond);
        public static readonly string[] PlayerNames = {"AI1", "AI2"};
        public static readonly List<IUnit>[] SevenNationArmies = new List<IUnit>[2];
        public static int TotalPrice = 300;
        public static readonly Invoker Invoker;
        public static IStrategy Strategy = new OneLineStrategy();
        public static bool DeadLock = false;

        public static readonly DeathLogger DeathLogger;
        public static readonly SpecialActionLogger SpecialActionLogger;
        public static readonly FightLogger FightLogger;

        public static readonly string FightFilePath;
        public static readonly string SpecialActionFilePath;
        public static readonly string DeathFilePath;

        static Consts()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);

            FightFilePath = Path.Combine(assemblyDirectory, "fight.txt");
            SpecialActionFilePath = Path.Combine(assemblyDirectory, "specialActions.txt");
            DeathFilePath = Path.Combine(assemblyDirectory, "deaths.txt");

            DeathLogger = new DeathLogger(DeathFilePath);
            SpecialActionLogger = new SpecialActionLogger(SpecialActionFilePath);
            FightLogger = new FightLogger(FightFilePath);

            Invoker = new Invoker(FightLogger, SpecialActionLogger, DeathLogger);
        }
    }
}

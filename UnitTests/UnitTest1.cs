using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern_Battle;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KnightsTest()
        {
            Consts.SevenNationArmies[0] = new List<IUnit>
            {
                /*new LightInfantryman(),
                new Archer(),*/
                new LightInfantryman(),
                new Knight(),
                new LightInfantryman()
            };
            Consts.SevenNationArmies[1] = new List<IUnit>
            {
                /*new LightInfantryman(),
                new Archer(),*/
                new LightInfantryman(),
                new Knight(),
                new LightInfantryman()
            };
            Core.SetIds();
            Core.TryBattleTick();
            Core.TryBattleTick();
            Consts.Invoker.CtrlZ();
            Consts.Invoker.CtrlY();
            Core.Battle();
        }
    }
}

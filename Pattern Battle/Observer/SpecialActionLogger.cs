using System.IO;
using Pattern_Battle.Command;

namespace Pattern_Battle.Observer
{
    public class SpecialActionLogger : ICommandsObserver
    {
        private StreamWriter _sw;
        private readonly string _filePath;

        public SpecialActionLogger(string path)
        {
            _filePath = path;
            using (_sw = new StreamWriter(_filePath)) { }
        }

        public void HandleEvent(ICommandArgs args)
        {
            string report = string.Empty;
            if (args is DamageOrHealCommandArgs)
            {
                var damageArgs = (DamageOrHealCommandArgs) args;
                if (!damageArgs.IsSpecialAction)
                    return;
                if (damageArgs.Points >= 0)
                {
                    report =
                        $"{damageArgs.Aim.FullName} suffers from {damageArgs.Dealer.FullName} with {damageArgs.Points}";
                }
                else
                {
                    report =
                        $"{damageArgs.Aim.FullName} healed by {damageArgs.Dealer.FullName} with {damageArgs.Points}";
                }
            }
            if (args is KillOrSpawnCommandArgs)
            {
                var killArgs = (KillOrSpawnCommandArgs) args;
                if (killArgs.Dealer == null)
                    return;
                report = $"{killArgs.Creature.FullName} spawned by {killArgs.Dealer.FullName}";
            }
            if (args is EquipOrUnEquipKnightCommandArgs)
            {
                var equipArgs = (EquipOrUnEquipKnightCommandArgs) args;
                if (equipArgs.Dealer == null)
                    report =
                        $"{equipArgs.Army[equipArgs.KnightPosition].FullName} was unweared.";
                else
                    report =
                        $"{equipArgs.Army[equipArgs.KnightPosition].FullName} was equiped by {equipArgs.Dealer.FullName}";
            }
            if (report != "")
                using (_sw = new StreamWriter(_filePath, true))
                {
                    _sw.WriteLine(report);
                }
        }
    }
}
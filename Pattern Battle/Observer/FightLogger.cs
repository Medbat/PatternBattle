using System.IO;
using Pattern_Battle.Command;

namespace Pattern_Battle.Observer
{
    public class FightLogger : ICommandsObserver
    {
        private StreamWriter _sw;
        private readonly string _filePath;

        public FightLogger(string path)
        {
            _filePath = path;
            using (_sw = new StreamWriter(_filePath)) { }
        }

        public void HandleEvent(ICommandArgs args)
        {
            string report = string.Empty;
            if (args == null)
                report = "Something strange happened";
            if (args is DamageOrHealCommandArgs)
            {
                var damageArgs = (DamageOrHealCommandArgs) args;
                if (damageArgs.Dealer.PlayerId != damageArgs.Aim.PlayerId && !damageArgs.IsSpecialAction)
                {
                    report =
                        $"{damageArgs.Aim.FullName} suffers from {damageArgs.Dealer.FullName} with {damageArgs.Points}" +
                        (damageArgs.IsSpecialAction
                            ? " (Special Action)"
                            : "" + $"\n Hp {damageArgs.Aim.FullName} [{damageArgs.Aim.HitPoints}]");
                }
                else
                {
                    report =
                        $"{damageArgs.Aim.FullName}[{damageArgs.Aim.HitPoints}] healed by {damageArgs.Dealer.FullName} with {damageArgs.Points} (Special Action) \n Hp {damageArgs.Aim.FullName} [{damageArgs.Aim.HitPoints}]";


                }
            }

			if (args is KillOrSpawnCommandArgs)
			{
				var killArgs = (KillOrSpawnCommandArgs)args;
				report = (killArgs.Dealer != null && killArgs.Dealer.PlayerId == killArgs.Creature.PlayerId)
					? $"{killArgs.Creature.FullName} cloned by {killArgs.Dealer.FullName}"
					: $"{killArgs.Creature.FullName} dies";
			}

            if (args is EquipOrUnEquipKnightCommandArgs)
            {
                var equipArgs = (EquipOrUnEquipKnightCommandArgs)args;
                if (equipArgs.Dealer == null)
                    report =
                        $"{equipArgs.Army[equipArgs.KnightPosition].FullName} was unweared." +
                        " (Special Action)";
                else
                    report =
                        $"{equipArgs.Army[equipArgs.KnightPosition].FullName} was equiped by {equipArgs.Dealer.FullName}" +
                        " (Special Action)";
            }
            
            if (args is FakeCommandArgs)
            {
                report = ((FakeCommandArgs) args).Undo ? "Undo done" : "Redo done";
            }
            if (report != "")
                using (_sw = new StreamWriter(_filePath, true))
                {
                    _sw.WriteLine(report);
                }
        }
    }
}
 
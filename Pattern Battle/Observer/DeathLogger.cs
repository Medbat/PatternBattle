using System.IO;
using Pattern_Battle.Command;

namespace Pattern_Battle.Observer
{
    public class DeathLogger : ICommandsObserver
    {
        private StreamWriter _sw;
        private readonly string _filePath;

        public DeathLogger(string path)
        {
            _filePath = path;
            using (_sw = new StreamWriter(_filePath)) { }
        }

        public void HandleEvent(ICommandArgs args)
        {
            var arguments = args as KillOrSpawnCommandArgs;
            if (arguments == null)
                return;
            using (_sw = new StreamWriter(_filePath, true))
            {
                _sw.WriteLine($"{arguments.Creature.FullName} dies");
            }
        }
    }
}
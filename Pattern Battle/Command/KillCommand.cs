using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class KillCommand : ICommandable
    {
        private readonly Reciever _reciever;
        private readonly List<IUnit> _army;
        private readonly IUnit _aim;
        private readonly int _position;
        private readonly IUnit _dealer;

        public KillCommand(Reciever reciever, List<IUnit> army, IUnit aim, int position, IUnit dealer)
        {
            _reciever = reciever;
            _army = army;
            _aim = aim;
            _position = position;
            _dealer = dealer;
        }

        public void Execute(bool isUndoRedo = false)
        {
            _reciever.Kill(_army, _position);
        }

        public void UnExecute(bool isUndoRedo = false)
        {
            _reciever.ResurrectOrSpawn(_army, _position, _aim);
        }
    }
}
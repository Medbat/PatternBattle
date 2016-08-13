using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class SpawnCommand : ICommandable
    {
        private readonly Reciever _reciever;
        private readonly List<IUnit> _army;
        private readonly IUnit _creature;
        private readonly int _position;
        private readonly IUnit _dealer;

        public SpawnCommand(Reciever reciever, List<IUnit> army, IUnit creature, int position, IUnit dealer)
        {
            _reciever = reciever;
            _army = army;
            _creature = creature;
            _position = position;
            _dealer = dealer;
        }

        public IUnit Dealer { get; set; }

        public void Execute(bool isUndoRedo = false)
        {
            _reciever.ResurrectOrSpawn(_army, _position, _creature);
        }

        public void UnExecute(bool isUndoRedo = false)
        {
            _reciever.Kill(_army, _position);
        }
    }
}
using Pattern_Battle.AbstractUnits;

namespace Pattern_Battle.Command
{
    public class DamageCommand : ICommandable
    {
        private readonly double _damage;
        private readonly IUnit _aim;
        private readonly Reciever _reciever;
        private readonly IUnit _dealer;
        
        public DamageCommand(Reciever reciever, IUnit aim, double damage, IUnit dealer)
        {
            _reciever = reciever;
            _aim = aim;
            _damage = damage;
            _dealer = dealer;
        }

        public void Execute(bool isUndoRedo = false)
        {
            _reciever.Damage(_aim, _damage, isUndoRedo);
        }

        public void UnExecute(bool isUndoRedo = false)
        {
            _reciever.Heal(_aim, _damage, isUndoRedo);
        }
    }
}
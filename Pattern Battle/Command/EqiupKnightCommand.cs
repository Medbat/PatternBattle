
using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Command
{
    public class EqiupKnightCommand : ICommandable
    {
        private readonly Reciever _reciever;
        private readonly List<IUnit> _army;
        private readonly int _knightPosition;
        private int _ammunitionNumber;
        private readonly IUnit _dealer;

        public EqiupKnightCommand(Reciever reciever, List<IUnit> army, int knightPosition, IUnit dealer)
        {
            _reciever = reciever;
            _army = army;
            _knightPosition = knightPosition;
            _dealer = dealer;
            _ammunitionNumber = -1;
        }

        public void Execute(bool isUndoRedo = false)
        {
            if (_ammunitionNumber == -1)
                _army[_knightPosition] = _reciever.EquipKnight(_army[_knightPosition] as Knight, ref _ammunitionNumber);
            else
                _army[_knightPosition] = _reciever.EquipKnight(_army[_knightPosition] as Knight, _ammunitionNumber);
        }

        public void UnExecute(bool isUndoRedo = false)
        {
            if (_ammunitionNumber == -1)
                _army[_knightPosition] = _reciever.UnEquipKnight(_army[_knightPosition] as Knight, ref _ammunitionNumber);
            else
                _army[_knightPosition] = _reciever.UnEquipKnight(_army[_knightPosition] as Knight, _ammunitionNumber);
        }
    }
}
using System.Collections.Generic;
using Pattern_Battle.AbstractUnits;
using Pattern_Battle.Units;

namespace Pattern_Battle.Command
{
    public class Reciever
    {
	    public void Damage(IUnit unit, double value, bool isUndoRedo)
	    {
		    if (isUndoRedo && unit is Knight)
				((Knight)unit).SafeHpChanging -= value;
		    else
				unit.HitPoints -= value;
	    }

	    public void Heal(IUnit unit, double value, bool isUndoRedo)
		{
			if (isUndoRedo && unit is Knight)
				((Knight)unit).SafeHpChanging += value;
			else
				unit.HitPoints += value;
        }

        public void Kill(List<IUnit> army, int position)
        {
            army.RemoveAt(position);
        }

        public void ResurrectOrSpawn(List<IUnit> army, int position, IUnit unit)
        {
            army.Insert(position, unit);
        }

        public Knight EquipKnight(Knight knight, ref int ammNum)
        {
            return knight.Wear(ref ammNum);
        }

        public Knight EquipKnight(Knight knight, int ammNum)
        {
            return knight.Wear(ammNum);
        }

        public Knight UnEquipKnight(Knight knight, ref int ammNum)
        {
            return knight.Unwear(ref ammNum);
        }
        public Knight UnEquipKnight(Knight knight, int ammNum)
        {
            return knight.Unwear(ammNum);
        }
    }
}
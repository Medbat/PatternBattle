namespace Pattern_Battle.AbstractUnits
{
    public abstract class Unit : IUnit
    {
        public virtual int PlayerId { get; set; }
        public virtual int UnitId { get; set; }
        public virtual string Name { get; set; }
        public virtual string FullName => $"{Name} ({PlayerId}.{UnitId})";

        public virtual double AttackPower { get; set; }
        public virtual double Defence { get; set; }
        public virtual double HitPoints { get; set; }

        public double Hit()
        {
            return AttackPower * (Consts.Rand.Next(11) / 10.0);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

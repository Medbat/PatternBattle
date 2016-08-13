namespace Pattern_Battle.AbstractUnits
{
    public abstract class HeavyUnit : Unit
    {
        public override double AttackPower { get; set; }
        public override double Defence { get; set; }
        public override double HitPoints { get; set; }
    }

}

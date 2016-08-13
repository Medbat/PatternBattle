namespace Pattern_Battle.AbstractUnits
{
    public interface IUnit
    {
        int PlayerId { get; set; }
        int UnitId { get; set; }
        string Name { get; set; }
        string FullName { get; }
        double AttackPower { get; set; }
        double Defence { get; set; }
        double HitPoints { get; set; }
        double Hit();
    }
}

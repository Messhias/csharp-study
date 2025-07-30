namespace BeehaviorManagementSystem;

public class NectarCollector : Bee
{
    public override float CostPerShift => 1.95f;

    public NectarCollector() : base("Nectar Collector")
    {
    }
}
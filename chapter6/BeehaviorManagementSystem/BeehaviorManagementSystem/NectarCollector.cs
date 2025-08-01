namespace BeehaviorManagementSystem;

public class NectarCollector() : Bee("Nectar Collector")
{
    private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

    protected override float CostPerShift => 1.95f;

    protected override void DoJob()
    {
        HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
    }
}
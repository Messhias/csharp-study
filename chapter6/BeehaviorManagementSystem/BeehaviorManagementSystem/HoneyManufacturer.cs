namespace BeehaviorManagementSystem;

public class HoneyManufacturer : Bee
{
    public const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;

    public HoneyManufacturer() : base("Honey Manufacturer")
    {
    }

    public override float CostPerShift => 1.7f;

    protected override void DoJob()
    {
        HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
    }
}
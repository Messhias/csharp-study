namespace BeehaviorManagementSystem;

public class HoneyManufacturer : Bee
{
    public override float CostPerShift => 1.7f;
    public const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;

    public HoneyManufacturer() : base("Honey Manufacturer")
    {
    }

    protected override void DoJob()
    {
        HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
    }
}
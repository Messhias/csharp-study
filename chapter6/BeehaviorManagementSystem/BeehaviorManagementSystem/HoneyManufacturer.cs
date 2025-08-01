namespace BeehaviorManagementSystem;

public class HoneyManufacturer() : Bee("Honey Manufacturer")
{
    private const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;

    protected override float CostPerShift => 1.7f;

    protected override void DoJob()
    {
        HoneyVault.ConvertNectarToHoney(NECTAR_COLLECTED_PER_SHIFT);
    }
}
namespace BeehaviorManagementSystem;

public class EggCare : Bee
{
    public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
    public override float CostPerShift => 1.35f;

    private Queen _queen;

    public EggCare(Queen queen) : base("Egg Care")
    {
        _queen = queen;
    }

    protected override void DoJob()
    {
        _queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
    }
}
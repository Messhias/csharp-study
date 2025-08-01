namespace BeehaviorManagementSystem;

public class Bee
{
    public Bee(string job)
    {
        Job = job;
    }

    public string Job { get; private set; }

    public virtual float CostPerShift { get; } = 0.0f;

    public void WorkTheNextShift()
    {
        var canWork = HoneyVault.ConsumeHoney(CostPerShift);

        if (canWork) DoJob();
    }

    protected virtual void DoJob()
    {
    }
}
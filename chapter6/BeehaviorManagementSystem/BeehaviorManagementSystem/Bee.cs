namespace BeehaviorManagementSystem;

public abstract class Bee
{
    public Bee(string job)
    {
        Job = job;
    }

    public string Job { get; private set; }

    protected abstract float CostPerShift { get; }

    public void WorkTheNextShift()
    {
        var canWork = HoneyVault.ConsumeHoney(CostPerShift);

        if (canWork) DoJob();
    }

    protected abstract void DoJob();
}
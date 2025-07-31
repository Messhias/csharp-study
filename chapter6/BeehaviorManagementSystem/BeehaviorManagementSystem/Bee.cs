namespace BeehaviorManagementSystem;

public class Bee
{
    public Bee(string job)
    {
        Job = job;
    }

    public string Job { get; private set; }

    public virtual float CostPerShift { get; } = 0.0f;

    public void WorkTheNextShift(float honeyConsumed)
    {
        var canWork = HoneyVault.ConsumeHoney(honeyConsumed);

        if (canWork) DoJob();
    }

    protected virtual void DoJob()
    {
    }
}
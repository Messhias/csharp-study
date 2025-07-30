namespace BeehaviorManagementSystem;

public class Bee
{
    public string Job { get; private set; }

    public virtual float CostPerShift { get; private set; }

    public Bee(string job)
    {
        Job = job;
    }

    public void WorkTheNextShift(float honeyConsumed)
    {
        var canWork = HoneyVault.ConsumeHoney(honeyConsumed);

        if (canWork)
        {
            DoJob();
        }
    }

    void DoJob()
    {
    }
}
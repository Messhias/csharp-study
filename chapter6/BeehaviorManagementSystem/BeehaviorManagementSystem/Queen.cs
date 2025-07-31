using System;

namespace BeehaviorManagementSystem;

public class Queen : Bee
{
    public const float EGGS_PERF_SHIFT = 0.45f;
    public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    private float _eggs;
    private float _unassignedWorkers = 3;
    private Bee[] _workers = new Bee[0];


    public Queen() : base("Queen")
    {
        AssignBee("Nectar Collector");
        AssignBee("Honey Manufacturer");
        AssignBee("Egg Care");
    }

    public string StatusReport { get; private set; }
    public override float CostPerShift => 2.15f;


    public void AssignBee(string job)
    {
        switch (job)
        {
            case "Egg Care":
                AddWorker(new EggCare(this));
                break;
            case "Honey Manufacturer":
                AddWorker(new HoneyManufacturer());
                break;
            default:
                AddWorker(new NectarCollector());
                break;
        }
    }

    private void AddWorker(Bee worker)
    {
        if (_unassignedWorkers >= 1)
        {
            _unassignedWorkers--;
            Array.Resize(ref _workers, _workers.Length + 1);
            _workers[_workers.Length - 1] = worker;
        }
    }

    private void UpdateStatusReport()
    {
        StatusReport = $"Vault report: \n{HoneyVault.StatusReport}\n" +
                       $"Egg count: {_eggs:0.0}\n" +
                       $"Worker count: {_workers.Length:0.0}\n" +
                       $"Unassigned Workers: {_unassignedWorkers:0.0}\n" +
                       $"{WorkerStatus("Honey Manufacturer")}\n" +
                       $"{WorkerStatus("Nectar Collector")}\n" +
                       $"{WorkerStatus("Egg Care")}\n";
    }

    private string WorkerStatus(string job)
    {
        var count = 0;
        foreach (var worker in _workers)
            if (worker.Job == job)
                count++;

        var s = "s";
        if (count == 1) s = "";

        return $"{count} {job} bee{s}";
    }

    public void CareForEggs(float eggsToConvert)
    {
        if (_eggs >= eggsToConvert)
        {
            _eggs -= eggsToConvert;
            _unassignedWorkers += eggsToConvert;
        }
    }

    protected override void DoJob()
    {
        _eggs += EGGS_PERF_SHIFT;
        foreach (var worker in _workers) worker.WorkTheNextShift(worker.CostPerShift);

        HoneyVault.ConsumeHoney(_unassignedWorkers + HONEY_PER_UNASSIGNED_WORKER);
        UpdateStatusReport();
    }
}
using System;

namespace BeehaviorManagementSystem;

public class Queen : Bee
{
    private float _eggs;
    private float _unassignedWorkers;

    private Bee[] _workers;

    public Queen() : base("Queen")
    {
    }

    public override float CostPerShift => 2.15f;

    private void AssignBee(string job)
    {
        switch (job)
        {
            case "Egg Care":
                AddWorker(new EggCare());
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
}
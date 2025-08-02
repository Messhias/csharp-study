using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BeehaviorManagementSystem;

public class Queen : Bee, INotifyPropertyChanged
{
    private const float EGGS_PERF_SHIFT = 0.45f;
    private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

    private float _eggs;
    private float _unassignedWorkers = 3;
    private IWorker[] _workers = [];


    public Queen() : base("Queen")
    {
        AssignBee("Nectar Collector");
        AssignBee("Honey Manufacturer");
        AssignBee("Egg Care");
    }

    public string StatusReport { get; private set; } = "";
    protected override float CostPerShift => 2.15f;


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
            case "Nectar Collector":
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
        OnPropertyChanged("StatusReport");
    }

    private string WorkerStatus(string job)
    {
        var count = _workers.Count(worker => worker.Job == job);

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
        foreach (var worker in _workers) worker.WorkTheNextShift();

        HoneyVault.ConsumeHoney(_unassignedWorkers + HONEY_PER_UNASSIGNED_WORKER);
        UpdateStatusReport();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
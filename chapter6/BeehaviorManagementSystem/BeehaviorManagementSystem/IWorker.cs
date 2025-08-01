namespace BeehaviorManagementSystem;

public interface IWorker
{
    string Job { get; protected internal set; }
    void WorkTheNextShift();
}
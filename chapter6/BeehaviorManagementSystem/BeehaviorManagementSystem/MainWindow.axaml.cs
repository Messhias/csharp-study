using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BeehaviorManagementSystem;

public partial class MainWindow : Window
{
    private readonly Queen _queen = new();

    public MainWindow()
    {
        InitializeComponent();
        StatusReport.Text = _queen.StatusReport;
    }

    private void WorkShift_Click(object? sender, RoutedEventArgs e)
    {
        _queen.WorkTheNextShift(_queen.CostPerShift);
        StatusReport.Text = _queen.StatusReport;
    }

    private void AssignJob_Click(object? sender, RoutedEventArgs e)
    {
        _queen.AssignBee(JobSelector.SelectedItem?.ToString());
        StatusReport.Text = _queen.StatusReport;
    }
}
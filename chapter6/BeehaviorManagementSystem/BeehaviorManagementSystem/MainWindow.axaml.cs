using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace BeehaviorManagementSystem;

public partial class MainWindow : Window
{
    private readonly Queen _queen = new();
    private readonly DispatcherTimer _timer = new  DispatcherTimer();

    public MainWindow()
    {
        InitializeComponent();
        StatusReport.Text = _queen.StatusReport;
        _timer.Tick += Timer_Tick;
        _timer.Interval = TimeSpan.FromSeconds(0.5);
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        WorkShift_Click(this, new RoutedEventArgs());
    }

    private void WorkShift_Click(object? sender, RoutedEventArgs e)
    {
        _queen.WorkTheNextShift();
        StatusReport.Text = _queen.StatusReport;
    }

    private void AssignJob_Click(object? sender, RoutedEventArgs e)
    {
        _queen.AssignBee(JobSelector.SelectedItem?.ToString());
        StatusReport.Text = _queen.StatusReport;
    }
}
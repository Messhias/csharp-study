using System;
using AbilityScoreTest;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace UI;

public partial class MainWindow : Window
{
    private Random random = new Random();
    SwordDamage swordDamage;
    
    public MainWindow()
    {
        InitializeComponent();
        swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
        DisplayDamage();
    }

    private void RollDice()
    {
        swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        DisplayDamage();
    }

    private void DisplayDamage()
    {
        damage.Text = swordDamage.ToString();
    }

    private void Flaming_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox checkBox) return;
        swordDamage.Flaming = checkBox.IsChecked ?? false;
        DisplayDamage();
    }

    private void Magic_OnIsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox checkBox) return;
        swordDamage.Magic = checkBox.IsChecked ?? false;
        DisplayDamage();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        RollDice();
    }
}
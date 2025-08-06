using System;
using System.Collections.Immutable;
using Avalonia.Controls;
using Avalonia;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace DeckCards;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        if (Resources["rightDeck"] is Deck rightDeck)
        {
            rightDeck.Clear();
        }
    }

    private void MoveCard(bool leftToRight)
    {
        if ((Resources["rightDeck"] is not Deck rightdeck) || (Resources["leftDeck"] is not Deck leftdeck)) return;
        
        if (leftToRight)
        {
            if (leftDeckListBox.SelectedItems is not Card card) return;
            
            leftdeck.Remove(card);
            rightdeck.Add(card);
        }
        else
        {
            if (rightDeckListBox.SelectedItem is not Card card) return;
            
            rightdeck.Remove(card);
            leftdeck.Add(card);
        }
    }

    private void ShuffleLeftDeck_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Resources["leftDeck"] is Deck leftDeck)
        {
            leftDeck.Shuffle();
        }
    }

    private void ResetLeftDeck_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Resources["leftDeck"] is Deck leftDeck)
        {
            leftDeck.Clear();
        }
    }

    private void ClearRightDec_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Resources["rightDeck"] is Deck rightDeck)
        {
            rightDeck.Clear();
        }
    }

    private void SortRightDec_OnClick(object? sender, RoutedEventArgs e)
    {
        if (Resources["rightDeck"] is Deck rightDeck)
        {
            rightDeck.Sort();
        }
    }

    private void LeftDeckListBox_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        MoveCard(true);
    }

    private void RightDeckListBox_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        MoveCard(false);
    }

    private void LeftDeckListBox_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MoveCard(true);
        }
    }

    private void RightDeckListBox_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MoveCard(false);
        }
    }
}
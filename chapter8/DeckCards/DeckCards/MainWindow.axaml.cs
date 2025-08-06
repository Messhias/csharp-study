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
        if ((Resources["rightDeck"] is Deck rightDeck)
            && (Resources["leftDeck"] is Deck leftDeck))
        {
            if (leftToRight)
            {
                if (leftDeckListBox.SelectedItem is Card card)
                {
                    leftDeck.Remove(card);
                    rightDeck.Add(card);
                }
            }
            else
            {
                if (rightDeckListBox.SelectedItem is Card card)
                {
                    rightDeck.Remove(card);
                    leftDeck.Add(card);
                }
            }
        }
    }

    private void leftDeckListBox_MouseDoubleClick(object sender, EventArgs e)
    {
        MoveCard(true);
    }

    private void rightDeckListBox_MouseDoubleClick(object sender, EventArgs e)
    {
        MoveCard(false);
    }

    private void leftDeckListBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MoveCard(true);
        }
    }

    private void rightDeckListBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            MoveCard(false);
        }
    }

    private void shuffleLeftDeck_Click(object sender, RoutedEventArgs e)
    {
        if (Resources["leftDeck"] is Deck leftDeck)
        {
            leftDeck.Shuffle();
        }
    }

    private void resetLeftDeck_Click(object sender, RoutedEventArgs e)
    {
        if (Resources["leftDeck"] is Deck leftDeck)
        {
            leftDeck.Reset();
        }
    }

    private void sortRightDeck_Click(object sender, RoutedEventArgs e)
    {
        if (Resources["rightDeck"] is Deck rightDeck)
        {
            rightDeck.Sort();
        }
    }

    private void clearRightDeck_Click(object sender, RoutedEventArgs e)
    {
        if (Resources["rightDeck"] is Deck rightDeck)
        {
            rightDeck.Clear();
        }
    }
}
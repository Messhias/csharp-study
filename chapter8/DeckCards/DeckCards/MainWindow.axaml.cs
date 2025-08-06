using Avalonia.Controls;
using Avalonia;

namespace DeckCards;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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
}
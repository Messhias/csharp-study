using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeckCards;

class Deck : ObservableCollection<Card>
{
    private static readonly Random Random = new();

    public Deck()
    {
        Reset();
    }

    public Card Deal(int index)
    {
        Card cardToDeal = base[index];
        RemoveAt(index);
        return cardToDeal;
    }

    public void Reset()
    {
        Clear();
        for (int suit = 0; suit <= 3; suit++)
        for (int value = 1; value <= 13; value++)
            Add(new Card((Values)value, (Suits)suit));
    }

    public void Shuffle()
    {
        List<Card> copy = new List<Card>(this);
        Clear();
        while (copy.Count > 0)
        {
            int index = Random.Next(copy.Count);
            Card card = copy[index];
            copy.RemoveAt(index);
            Add(card);
        }
    }

    public void Sort()
    {
        List<Card> sortedCards = new List<Card>(this);
        sortedCards.Sort(new ComparerByValue());
        Clear();
        foreach (Card card in sortedCards)
        {
            Add(card);
        }
    }
}

internal class ComparerByValue : IComparer<Card>
{
    public int Compare(Card x, Card y)
    {
        if (x.Suit < y.Suit)
            return -1;
        if (x.Suit > y.Suit)
            return 1;
        if (x.Value < y.Value)
            return -1;
        return x.Value > y.Value ? 1 : 0;
    }
}
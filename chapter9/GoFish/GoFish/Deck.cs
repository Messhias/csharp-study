using System.Collections.ObjectModel;

namespace GoFish;

public class Deck : ObservableCollection<Card>
{
    private static readonly Random Random = Player.Random;

    public Deck()
    {
        Reset();
    }

    public Card Deal(int index)
    {
        var cardToDeal = base[index];
        RemoveAt(index);
        return cardToDeal;
    }

    public void Reset()
    {
        Clear();
        for (var suit = 0; suit <= 3; suit++)
        for (var value = 1; value <= 13; value++)
            Add(new Card((Values)value, (Suits)suit));
    }

    public Deck Shuffle()
    {
        var copy = new List<Card>(this);
        Clear();
        while (copy.Count > 0)
        {
            var index = Random.Next(copy.Count);
            var card = copy[index];
            copy.RemoveAt(index);
            Add(card);
        }

        return this;
    }

    public void Sort()
    {
        var sortedCards = new List<Card>(this);
        sortedCards.Sort(new ComparerByValue());
        Clear();
        foreach (var card in sortedCards) Add(card);
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
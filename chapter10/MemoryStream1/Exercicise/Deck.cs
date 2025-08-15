using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Exercicise;

internal class Deck : ObservableCollection<Card>
{
    private static readonly Random Random = new();

    public Deck(string filename)
    {
        using var reader = new StreamReader(filename);
        while (reader.EndOfStream == false)
        {
            var nextCard = reader.ReadLine();
            nextCard = nextCard?.Replace(" of", "");
            var cardParts = nextCard?.Split(new char[]{' '});
            var value = cardParts?[0] switch
            {
                "Ace" => Values.Ace,
                "Two" => Values.Two,
                "Three" => Values.Three,
                "Four" => Values.Four,
                "Five" => Values.Five,
                "Six" => Values.Six,
                "Seven" => Values.Seven,
                "Eight" => Values.Eight,
                "Nine" => Values.Nine,
                "Ten" => Values.Ten,
                "Jack" => Values.Jack,
                "Queen" => Values.Queen,
                "King" => Values.King,
                _ => throw new InvalidDataContractException($"Unrecognized card value: {cardParts?[0]}"),
            };

            var suit = cardParts[1] switch
            {
                "Spades" => Suits.Spades,
                "Clubs" => Suits.Clubs,
                "Hearts" => Suits.Hearts,
                "Diamonds" => Suits.Diamonds,
                _ => throw new InvalidDataContractException($"Unrecognized card suit: {cardParts[1]}"),
            };
                
            Add(new Card(value, suit));
        }
    }

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
        for (int value = 1; value < 13; value++)
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

    public void WriteCards(string filename)
    {
        using (StreamWriter writer = new(filename))
        {
            for (int i = 0; i < Count; i++)
            {
                writer.WriteLine(this[i].Name);
            }
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

public class Card : IComparable<Card>
{
    public Values Values { get; private set; }
    public Suits Suit { get; private set; }

    public string Name => $"{Values} of {Suit}";

    public Card(Values values, Suits suit)
    {
        Values = values;
        Suit = suit;
    }

    public int CompareTo(Card? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        var valuesComparison = Values.CompareTo(other.Values);
        if (valuesComparison != 0) return valuesComparison;
        return Suit.CompareTo(other.Suit);
    }
}
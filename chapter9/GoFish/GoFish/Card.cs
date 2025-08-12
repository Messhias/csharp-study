namespace GoFish;

public class Card
{
    public Card(Values value, Suits suit)
    {
        Suit = suit;
        Value = value;
    }

    public Values Value { get; }
    public Suits Suit { get; }
    public string Name => $"{Value} of {Suit}";

    public override string ToString()
    {
        return Name;
    }
}
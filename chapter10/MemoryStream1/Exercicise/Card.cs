namespace Exercicise;
public class Card
{
    
    public Values Value { get; private set; }
    public Suits Suit { get; private set; }

    public Card(Values value, Suits suit)
    {
        Suit = suit;
        Value = value;
    }
    public string Name => $"{Value} of {Suit}";

    public override string ToString()
    {
        return Name;
    }
}
namespace DeckCards;
public class Card
{
    public Values Values { get; private set; }
    public Suits Suit { get; private set; }

    public string Name => $"{Values} of  {Suit}";

    public Card(Values values, Suits suit)
    {
        Values = values;
        Suit = suit;
    }
}
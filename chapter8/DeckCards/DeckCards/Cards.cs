namespace DeckCards;
public class Cards
{
    public Values Values { get; private set; }
    public Suits Suit { get; private set; }

    public string Name => $"{Values} of  {Suit}";

    public Cards(Values values, Suits suit)
    {
        Values = values;
        Suit = suit;
    }
}
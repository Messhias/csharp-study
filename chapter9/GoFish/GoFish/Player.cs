namespace GoFish;

public class Player
{
    public static Random Random = new();

    public readonly string Name;
    private readonly List<Values> _books = new();

    private readonly List<Card> _hand = new();

    public Player(string name)
    {
        Name = name;
    }

    public Player(string name, IEnumerable<Card> cards)
    {
        Name = name;
        _hand.AddRange(cards);
    }

    public IEnumerable<Card> Hand => _hand;
    public IEnumerable<Values> Books => _books;

    public string Status => $"{Name} has {_hand.Count} and {_books.Count} books";

    public static string S(int s)
    {
        return s == 1 ? "" : "S";
    }

    public void GetNextHand(Deck stock)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
    {
        throw new NotImplementedException();
    }

    public void AddCardsAndPullOutBooks(IEnumerable<Card> cards)
    {
        throw new NotImplementedException();
    }

    public void DrawCard(Deck stock)
    {
        throw new NotImplementedException();
    }

    // Use LINQ to implement RandomValueFromHand:
    // first order the list by card value, then select the
    // value of each card, skip a random number of
    // cards, and choose the first element in the result.
    public Values RandomValueFromHand()
    {
        return _hand.OrderBy(h => h.Value)
            .Select(h => h.Value)
            .Skip(Random.Next())
            .FirstOrDefault();
    }

    public override string ToString()
    {
        return Name;
    }
}
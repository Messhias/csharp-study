namespace GoFish;

public class Player
{
    public static Random Random = new();
    public string Name {get; private set;}

    private readonly List<Values> _books = new();
    private List<Card> _hand = new();

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

    public string Status =>
        $"{Name} has {_hand.Count} card{S(_hand.Count)} and {_books.Count} book{S(_books.Count)}";

    internal static string S(int s)
    {
        return s == 1 ? "" : "s";
    }

    public void GetNextHand(Deck stock)
    {
        while (stock.Any() && _hand.Count < 5) _hand.Add(stock.Deal(0));
    }

    public IEnumerable<Card> DoYouHaveAny(Values value, Deck deck)
    {
        var matchingCards = _hand.Where(card => card.Value == value)
            .OrderBy(card => card.Suit);
        _hand = _hand.Where(card => card.Value != value).ToList();
        if (_hand.Count == 0)
            GetNextHand(deck);

        return matchingCards;
    }

    public void AddCardsAndPullOutBooks(IEnumerable<Card> cards)
    {
        _hand.AddRange(cards);
        var foundBooks = _hand
            .GroupBy(card => card.Value)
            .Where(group => group.Count() == 4)
            .Select(group => group.Key);

        _books.AddRange(foundBooks);
        _books.Sort();

        _hand = _hand
            .Where(card => !_books.Contains(card.Value))
            .ToList();
    }

    public void DrawCard(Deck stock)
    {
        if (stock.Count > 0)
            AddCardsAndPullOutBooks(new List<Card> { stock.Deal(0) });
    }

    // Use LINQ to implement RandomValueFromHand:
    // first order the list by card value, then select the
    // value of each card, skip a random number of
    // cards, and choose the first element in the result.
    public Values RandomValueFromHand()
    {
        return _hand.OrderBy(h => h.Value)
            .Select(h => h.Value)
            .Skip(Random.Next(_hand.Count))
            .FirstOrDefault();
    }

    public override string ToString()
    {
        return Name;
    }
}
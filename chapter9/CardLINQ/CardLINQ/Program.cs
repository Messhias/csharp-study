using CardLINQ;

var deck = new Deck().Shuffle().Take(16);

var grouped = OrderLinqQuery(deck);

foreach (var group in grouped)
{
    PrintInfo(group);
}

PencilPointerChapter9();

return;

void PencilPointerChapter9()
{
    var deck = new Deck();

    var processedCards = deck
        .Take(3)
        .Concat(deck.TakeLast(3))
        .OrderByDescending(card => card)
        .Select(card => card.Value switch
        {
            Values.King => Output(card.Suit, 7),
            Values.Ace => $"It's a ace! {card.Suit}",
            Values.Jack => Output((Suits)card.Suit - 1, 9),
            _ => card.ToString(),
        });

    foreach (var processedCard in processedCards)
    {
        Console.WriteLine(processedCard);
    }
}
static string Output(Suits suit, int number) => $"Suit is {suit} and number is {number}.";

IOrderedEnumerable<IGrouping<Suits, Card>> OrderLinqQuery(IEnumerable<Card> enumerable) => from card in enumerable
    group card by card.Suit
    into suitGroup
    orderby suitGroup.Key descending
    select suitGroup;

void PrintInfo(IGrouping<Suits, Card> grouping)
{
    Console.WriteLine("---------------");
    Console.WriteLine(@$"Group {grouping.Key}.
Count: {grouping.Count()}.
Minimum: {grouping.Min()}.
Maximum: {grouping.Max()}.");
}
using CardLINQ;

var deck = new Deck().Shuffle().Take(16);

var grouped = OrderLinqQuery(deck);

foreach (var group in grouped)
{
    PrintInfo(group);
}

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
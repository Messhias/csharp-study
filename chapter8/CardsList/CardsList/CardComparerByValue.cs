public class CardComparerByValue : IComparer<Card>
{
    public int Compare(Card? x, Card? y)
    {
        if (x?.Suit < y?.Suit)
        {
            return -1;
        }

        if (x?.Suit > y?.Suit)
        {
            return 1;
        }

        if (x?.Values < y?.Values)
        {
            return -1;
        }

        return x?.Values > y.Values ? 1 : 0;
    }
}
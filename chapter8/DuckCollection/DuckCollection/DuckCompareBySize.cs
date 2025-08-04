public class DuckCompareBySize : IComparer<Duck>
{
    public int Compare(Duck? x, Duck? y)
    {
        if (x?.Size < y?.Size) return -1;
        return x?.Size > y?.Size ? 1 : 0;
    }
}
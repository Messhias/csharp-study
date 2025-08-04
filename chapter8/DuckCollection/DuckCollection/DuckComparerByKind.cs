public class DuckComparerByKind : IComparer<Duck>
{
    public int Compare(Duck? x, Duck? y)
    {
        if (x?.Kind == y?.Kind)  return 0;
        if (x?.Kind >  y?.Kind) return -1;
        return x?.Kind < y?.Kind ? 1 : 0;
    }
}
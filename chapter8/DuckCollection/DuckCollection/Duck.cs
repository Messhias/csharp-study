public class Duck : Bird, IComparable<Duck>
{
    private string _name => $"{Size} of {Kind}";
    
    public int Size
    {
        get;
        set;
    }

    public KindOfDuck Kind
    {
        get;
        set;
    }

    public int CompareTo(Duck? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        var sizeComparison = Size.CompareTo(other.Size);
        if (sizeComparison != 0) return sizeComparison;

        if (this.Size > other.Size) return 1;
        if (this.Size < other.Size) return -1;
        
        return Kind.CompareTo(other.Kind);
    }

    public override string ToString() => _name;
}

public enum KindOfDuck
{
    Mallard,
    Muscovy,
    Loon,
}
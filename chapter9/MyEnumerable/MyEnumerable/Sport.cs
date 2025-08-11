using System.Collections;

namespace MyEnumerable;

internal enum Sport
{
    Football,
    Baseball,
    Basketball,
    Hockey,
    Boxing,
    Rugby,
    Fencing,
}

internal class ManualSportSequence : IEnumerable<Sport>
{
    public IEnumerator<Sport> GetEnumerator()
    {
        return new ManualSportEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class ManualSportEnumerator : IEnumerator<Sport>
{
    int _current = -1;

    public Sport Current
    {
        get { return (Sport)_current; }
    }

    public void Dispose()
    {
        return;
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public bool MoveNext()
    {
        var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        if ((int)_current >= maxEnumValue - 1)
            return false;
        _current++;
        return true;
    }

    public void Reset()
    {
        _current = 0;
    }
}
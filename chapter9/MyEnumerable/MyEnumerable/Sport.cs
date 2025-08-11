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
    public Sport this[int index] => (Sport)index;

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
    private int _current = -1;

    public Sport Current => (Sport)_current;

    public void Dispose()
    {
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        if (_current >= maxEnumValue - 1)
            return false;
        _current++;
        return true;
    }

    public void Reset()
    {
        _current = 0;
    }
}

internal class BetterSportSequence : IEnumerable<Sport>
{
    public Sport this[int index] => (Sport)index;
    
    public IEnumerator<Sport> GetEnumerator()
    {
        int maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        for (int i = 0; i < maxEnumValue - 1; i++)
        {
            yield return (Sport)i;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
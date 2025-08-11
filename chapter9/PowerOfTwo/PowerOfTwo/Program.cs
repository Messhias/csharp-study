using System.Collections;

var power = new PowerOfTwo();

foreach (var p in power)
{
    Console.Write($"{p} ");
}

internal class PowerOfTwo : IEnumerable<int>
{
    public IEnumerator<int> GetEnumerator()
    {
        var maximumPowerOfTwo = Math.Round(Math.Log(int.MaxValue, 2));

        for (int power = 0; power <= maximumPowerOfTwo; power++)
        {
            yield return (int)Math.Pow(2, power);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
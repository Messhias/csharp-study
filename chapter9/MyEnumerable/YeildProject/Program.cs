static IEnumerable<string> SimpleEnumerable()
{
    yield return "A";
    yield return "B";
    yield return "C";
    yield return "D";
    yield return "E";
    yield return "F";
}

foreach (var result in SimpleEnumerable())
{
    Console.Write(result);
}
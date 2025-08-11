using MyEnumerable;

var sports = new ManualSportSequence();
Console.WriteLine(sports[2]);
foreach (var sport in sports)
{
    Console.WriteLine(sport);
}

Console.WriteLine("------------");

var betterSequence = new BetterSportSequence();
Console.WriteLine(betterSequence[3]);
foreach (var result in betterSequence)
{
    Console.WriteLine(result);
}
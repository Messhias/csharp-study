using System.Linq;

List<int> numbers = new();

for (int i = 0; i < 100; i++)
{
    numbers.Add(i);
}

IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(
    numbers.TakeLast(5)
);

foreach (int i in firstAndLastFive)
{
    Console.WriteLine(i);
}
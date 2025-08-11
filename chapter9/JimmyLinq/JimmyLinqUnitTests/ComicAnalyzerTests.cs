using JimmyLinq;

namespace JimmyLinqUnitTests;

public class ComicAnalyzerTests
{
    private readonly IEnumerable<Comics> _testComics =
    [
        new() { Issue = 1, Name = "Issue 1" },
        new() { Issue = 2, Name = "Issue 2" },
        new() { Issue = 3, Name = "Issue 3" }
    ];

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ComicAnalyzer_Should_Group_Comics()
    {
        var prices = new Dictionary<int, decimal>()
        {
            { 1, 20M },
            { 2, 10M },
            { 3, 1000M },
        };

        var groups = ComicAnalyzer.GroupComicsByPrice(_testComics, prices);

        var enumerable = groups as IGrouping<PriceRange, Comics>[] ?? groups.ToArray();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(enumerable.Count(), Is.EqualTo(2));
            Assert.That(enumerable.First().Key, Is.EqualTo(PriceRange.Cheap));
            Assert.That(enumerable.First().First().Issue, Is.EqualTo(2));
            Assert.That(enumerable.First().First().Name, Is.EqualTo("Issue 2"));
        }
    }
}
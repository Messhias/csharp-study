using JimmyLinq;

namespace JimmyLinqUnitTests;

public class ComicAnalyzerTests
{
    private IEnumerable<Comics> testComics = new[]
    {
        new Comics() { Issue = 1, Name = "Issue 1" },
        new Comics() { Issue = 2, Name = "Issue 2" },
        new Comics() { Issue = 3, Name = "Issue 3" },
    };

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

        var groups = ComicAnalyzer.GroupComicsByPrice(testComics, prices);

        Assert.That(2, Is.EqualTo(groups.Count()));
        Assert.That(PriceRange.Cheap, Is.EqualTo(groups.First().Key));
        Assert.That(2, Is.EqualTo(groups.First().First().Issue));
        Assert.That("Issue 2",  Is.EqualTo(groups.First().First().Name));
    }
}
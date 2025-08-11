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
        var prices = new Dictionary<int, decimal>
        {
            { 1, 20M },
            { 2, 10M },
            { 3, 1000M }
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

    [Test]
    public void ComicAnalyzer_Should_Have_Review()
    {
        IEnumerable<Review> testReviews =
        [
            new() { Issue = 1, Critic = Critics.MuddyCritic, Score = 1 },
            new() { Issue = 1, Critic = Critics.RottenTornadoes, Score = 4 },
            new() { Issue = 2, Critic = Critics.MuddyCritic, Score = 1 },
            new() { Issue = 2, Critic = Critics.RottenTornadoes, Score = 3 },
            new() { Issue = 3, Critic = Critics.MuddyCritic, Score = 3 },
            new() { Issue = 3, Critic = Critics.RottenTornadoes, Score = 1 }
        ];

        var expectedResults = new[]
        {
            "MuddyCritic rated #1 'Issue 1' 1",
            "RottenTornadoes rated #1 'Issue 1' 4",
            "MuddyCritic rated #2 'Issue 2' 1",
            "RottenTornadoes rated #2 'Issue 2' 3",
            "MuddyCritic rated #3 'Issue 3' 3",
            "RottenTornadoes rated #3 'Issue 3' 1"
        };

        var actualResults = ComicAnalyzer.GetReviews(_testComics, testReviews);

        Assert.That(actualResults, Is.EqualTo(expectedResults).AsCollection);
    }

    [Test]
    public void ComicAnalyzer_Should_Handle_Weird_Review_Scores()
    {
        var testReviews = new[]
        {
            new Review { Issue = 1, Critic = Critics.MuddyCritic, Score = -12.1212 },
            new Review { Issue = 1, Critic = Critics.RottenTornadoes, Score = 391691234.48931 },
            new Review { Issue = 2, Critic = Critics.RottenTornadoes, Score = 0 },
            new Review { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3 },
            new Review { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3 },
            new Review { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3 },
            new Review { Issue = 2, Critic = Critics.MuddyCritic, Score = 40.3 }
        };

        var expectedResults = new[]
        {
            "MuddyCritic rated #1 'Issue 1' -12,1212",
            "RottenTornadoes rated #1 'Issue 1' 391691234,48931",
            "RottenTornadoes rated #2 'Issue 2' 0",
            "MuddyCritic rated #2 'Issue 2' 40,3",
            "MuddyCritic rated #2 'Issue 2' 40,3",
            "MuddyCritic rated #2 'Issue 2' 40,3",
            "MuddyCritic rated #2 'Issue 2' 40,3"
        };

        var actualResults = ComicAnalyzer.GetReviews(_testComics, testReviews).ToList();
        Assert.That(actualResults, Is.EqualTo(expectedResults).AsCollection);
    }
}
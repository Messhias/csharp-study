using GoFish;

namespace GoFishTests;

[TestClass]
public sealed class PlayerTests
{
    [TestMethod]
    public void TestGetNextHand()
    {
        var player = new Player("Owner", new List<Card>());
        player.GetNextHand(new Deck());

        var expected = new Deck().Take(5).Select(card => card.ToString()).ToList();
        var actual = player.Hand.Select(card => card.ToString()).ToList();

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDoYouHaveAny()
    {
        IEnumerable<Card> cards = new List<Card>
        {
            new(Values.Jack, Suits.Spades),
            new(Values.Three, Suits.Clubs),
            new(Values.Three, Suits.Hearts),
            new(Values.Four, Suits.Diamonds),
            new(Values.Three, Suits.Diamonds),
            new(Values.Jack, Suits.Clubs)
        };

        var player = new Player("Owner", cards);

        var threes = player.DoYouHaveAny(Values.Three, new Deck())
            .Select(card => card.ToString())
            .ToList();

        CollectionAssert.AreEqual(new List<string>
        {
            "Three of Diamonds",
            "Three of Clubs",
            "Three of Hearts"
        }, threes);

        var hand = player.Hand.Select(card => card.ToString()).ToList();
        CollectionAssert.AreEqual(new List<string>
        {
            "Four of Diamonds"
        }, hand);

        Assert.AreEqual("Owen has 1 card and 0 books", player.Status);
    }

    [TestMethod]
    public void TestAddClassAndPullOutBooks()
    {
        IEnumerable<Card> cards = new List<Card>
        {
            new(Values.Jack, Suits.Spades),
            new(Values.Three, Suits.Clubs),
            new(Values.Jack, Suits.Hearts),
            new(Values.Three, Suits.Hearts),
            new(Values.Four, Suits.Diamonds),
            new(Values.Jack, Suits.Diamonds),
            new(Values.Jack, Suits.Clubs)
        };

        var player = new Player("Owner", cards);

        Assert.AreEqual(0, player.Books.Count());

        var cardsToAdd = new List<Card>
        {
            new(Values.Three, Suits.Diamonds),
            new(Values.Three, Suits.Spades)
        };
        player.AddCardsAndPullOutBooks(cardsToAdd);

        var books = player.Books.ToList();
        Assert.AreEqual(new List<Values>
        {
            Values.Three, Values.Jack
        }, books);

        var hand = player.Hand.Select(card => card.ToString()).ToList();
        Assert.AreEqual(["Four Diamonds"], hand);

        Assert.AreEqual("Owen has 1 card and 2 books", player.Status);
    }

    [TestMethod]
    public void TestDrawCard()
    {
        var player = new Player("Owner", new Deck());
        player.DrawCard(new Deck());
        Assert.AreEqual(1, player.Books.Count());
        Assert.AreEqual("Ace of Diamonds", player.Hand.First().ToString());
    }

    [TestMethod]
    public void TestRandomValueFromHand()
    {
        var player = new Player("Owner", new Deck());
        Player.Random = new MockRandom
        {
            ValueToReturn = 0
        };
        Assert.AreEqual("Ace", player.RandomValueFromHand().ToString());

        Player.Random = new MockRandom
        {
            ValueToReturn = 4
        };
        Assert.AreEqual("Two", player.RandomValueFromHand().ToString());

        Player.Random = new MockRandom
        {
            ValueToReturn = 8
        };
        Assert.AreEqual("Three", player.RandomValueFromHand().ToString());
    }
}

public class MockRandom : Random
{
    public int ValueToReturn { get; set; }

    public override int Next() => ValueToReturn;

    public override int Next(int maxValue) => ValueToReturn;

    public override int Next(int minValue, int maxValue) => ValueToReturn;
}
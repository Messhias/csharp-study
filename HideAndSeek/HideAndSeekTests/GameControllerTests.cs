using HideAndSeek;

namespace HideAndSeekTests;

[TestClass]
public class GameControllerTests
{
    GameController gameController;

    [TestInitialize]
    public void Initialize()
    {
        gameController = new GameController();
    }

    [TestMethod]
    public void TestMovement()
    {
        Assert.AreEqual("Entry", gameController.CurrentLocation.Name);
        Assert.IsFalse(gameController.Move(Direction.Up));
        Assert.AreEqual("Entry", gameController.CurrentLocation.Name);
        Assert.IsTrue(gameController.Move(Direction.East));
        Assert.AreEqual("Hallway", gameController.CurrentLocation.Name);
        Assert.IsTrue(gameController.Move(Direction.Up));
        Assert.AreEqual("Landing", gameController.CurrentLocation.Name);
    }

    [TestMethod]
    public void TestParseInput()
    {
        var initialStatus = gameController.Status;
        Assert.AreEqual("That's not a valid direction", gameController.ParseInput("X"));
        Assert.AreEqual(initialStatus, gameController.Status);
        Assert.AreEqual("There's no exit in that direction", gameController.ParseInput("Up"));
        Assert.AreEqual(initialStatus, gameController.Status);
        Assert.AreEqual("Moving East", gameController.ParseInput("East"));
        Assert.AreEqual(@"You are in the Hallway. You see the following exits:
 - the Entry is to the West
 - the Kitchen is to the Northwest
 - the Bathroom is to the North
 - the Living Room is to the South
 - the Landing is to the Up", gameController.Status
        );
        Assert.AreEqual("Moving South", gameController.ParseInput("South"));
        Assert.AreEqual(
            "You are in the Living Room. You see the following exits:" + Environment.NewLine +
            " - the Hallway is to the North", gameController.Status);
    }
}
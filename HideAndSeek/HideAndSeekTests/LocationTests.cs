using HideAndSeek;

namespace HideAndSeekTests;

[TestClass]
public sealed class LocationTests
{
    private Location _center;


    [TestInitialize]
    public void Initialize()
    {
        _center = new Location("Center Room");
        Assert.AreSame("Center Room", _center.ToString());
        Assert.AreEqual(0, _center.ExitList.Count());

        _center.AddExit(Direction.North, new Location("North Room"));
        _center.AddExit(Direction.Northeast, new Location("Northeast Room"));
        _center.AddExit(Direction.East, new Location("East Room"));
        _center.AddExit(Direction.Southeast, new Location("Southeast Room"));
        _center.AddExit(Direction.South, new Location("South Room"));
        _center.AddExit(Direction.Southwest, new Location("East Room"));
        _center.AddExit(Direction.West, new Location("West Room"));
        _center.AddExit(Direction.Northwest, new Location("Northwest Room"));
        _center.AddExit(Direction.Up, new Location("Upper Room"));
        _center.AddExit(Direction.Down, new Location("Lower Room"));
        _center.AddExit(Direction.In, new Location("Inside Room"));
        _center.AddExit(Direction.Out, new Location("Outside Room"));

        Assert.AreEqual(12, _center.ExitList.Count());
    }

    [TestMethod]
    public void TestGetExit()
    {
        var eastRoom = _center.GetExit(Direction.East);
        Assert.AreEqual("East Room", eastRoom.Name);
        Assert.AreSame(_center, eastRoom.GetExit(Direction.West));
        Assert.AreSame(eastRoom, eastRoom.GetExit(Direction.Up));
    }

    [TestMethod]
    public void TestExitList()
    {
        var eastRoom = _center.GetExit(Direction.East);
        Assert.AreEqual("East Room", eastRoom.Name);
        Assert.AreSame(_center, eastRoom.GetExit(Direction.West));
        Assert.AreSame(eastRoom, eastRoom.GetExit(Direction.Up));
    }

    [TestMethod]
    public void TestReturnExists()
    {
    }

    [TestMethod]
    public void TestAddHall()
    {
    }

    /// <summary>
    /// Describes a direction (e.g. "in" vs. "to the North")
    /// </summary>
    /// <param name="d">Direction to describe</param>
    /// <returns>string describing the direction</returns>
    private string DescribeDirection(Direction d) => d switch
    {
        Direction.Up => "Up",
        Direction.Down => "Down",
        Direction.In => "In",
        Direction.Out => "Out",
        _ => $"to the {d}",
    };
}
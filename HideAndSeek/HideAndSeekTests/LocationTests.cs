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
        var e = _center.GetExit(Direction.East);
        Assert.AreEqual("East Room", e.ToString());
        Assert.AreSame(_center, e.GetExit(Direction.West));
        Assert.AreEqual(1, e.ExitList.Count());

        var nw = _center.GetExit(Direction.Northwest);
        Assert.AreEqual("Northwest Room", nw.ToString());
        Assert.AreSame(_center, nw.GetExit(Direction.Southeast));

        var se = _center.GetExit(Direction.Southeast);
        Assert.AreEqual("Southeast Room", se.ToString());
        Assert.AreSame(_center, se.GetExit(Direction.Northwest));

        var s = _center.GetExit(Direction.South);
        Assert.AreEqual("South Room", s.ToString());
        Assert.AreSame(_center, s.GetExit(Direction.North));

        var up = _center.GetExit(Direction.Up);
        Assert.AreEqual("Upper Room", up.ToString());
        Assert.AreSame(_center, up.GetExit(Direction.Down));

        var outside = _center.GetExit(Direction.Out);
        Assert.AreEqual("Outside Room", outside.ToString());
        Assert.AreSame(_center, outside.GetExit(Direction.In));
    }

    [TestMethod]
    public void TestAddHall()
    {
        var e = _center.GetExit(Direction.East);
        Assert.AreEqual(1, e.ExitList.Count());
        var eastHall1 = new Location("East hall 1");
        var eastHall2 = new Location("East hall 2");
        e.AddExit(Direction.East, eastHall1);
        eastHall1.AddExit(Direction.East, eastHall2);
        Assert.AreEqual(2, e.ExitList.Count());
        Assert.AreEqual(2, eastHall1.ExitList.Count());
        Assert.AreEqual(1, eastHall2.ExitList.Count());
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
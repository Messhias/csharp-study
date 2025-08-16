namespace HideAndSeek;

public static class House
{
    public static readonly Location Entry;

    /// <summary>
    /// Private collection of locations in the house
    /// </summary>
    private static readonly IEnumerable<Location> Locations;

    public static Random Random = new();

    static House()
    {
        Entry = new Location("Entry");
        var hallway = new Location("Hallway");
        var livingRoom = new Location("Living Room");
        var kitchen = new Location("Kitchen");
        var bathroom = new Location("Bathroom");
        var landing = new Location("Landing");
        var masterBedroom = new Location("Master Bedroom");
        var masterBath = new Location("Master Bath");
        var secondBathroom = new Location("Second Bathroom");
        var kidsRoom = new Location("Kids Room");
        var nursery = new Location("Nursery");
        var pantry = new Location("Pantry");
        var attic = new Location("Attic");
        var garage = new Location("Garage");

        EntrySetup(hallway, garage);
        HallwaySetup(hallway, kitchen, bathroom, livingRoom, landing);
        LandingSetup(landing, masterBedroom, secondBathroom, nursery, pantry, kidsRoom, attic);

        masterBedroom.AddExit(Direction.East, masterBath);

        Locations = new List<Location>
        {
            Entry,
            hallway,
            kitchen,
            bathroom,
            livingRoom,
            landing,
            masterBedroom,
            secondBathroom,
            kidsRoom,
            nursery,
            pantry,
            attic,
            garage,
            attic,
            masterBath,
        };
    }

    private static void LandingSetup(Location landing, Location masterBedroom, Location secondBathroom,
        Location nursery,
        Location pantry, Location kidsRoom, Location attic)
    {
        landing.AddExit(Direction.Northwest, masterBedroom);
        landing.AddExit(Direction.West, secondBathroom);
        landing.AddExit(Direction.Southwest, nursery);
        landing.AddExit(Direction.South, pantry);
        landing.AddExit(Direction.Southeast, kidsRoom);
        landing.AddExit(Direction.Up, attic);
    }

    private static void HallwaySetup(Location hallway, Location kitchen, Location bathroom, Location livingRoom,
        Location landing)
    {
        hallway.AddExit(Direction.Northwest, kitchen);
        hallway.AddExit(Direction.North, bathroom);
        hallway.AddExit(Direction.South, livingRoom);
        hallway.AddExit(Direction.Up, landing);
    }

    private static void EntrySetup(Location hallway, Location garage)
    {
        Entry.AddExit(Direction.East, hallway);
        Entry.AddExit(Direction.Out, garage);
    }

    public static Location GetLocationByName(string name) => (
        Locations.Where(l => l.Name == name) as Location[] ??
        Locations.Where(l => l.Name == name).ToArray()
    ).ToList().Count != 0
        ? (
            Locations.Where(l => l.Name == name) as Location[] ??
            Locations.Where(l => l.Name == name).ToArray()
        ).ToList().First()
        : Entry;

    public static Location RandomExit(Location exit) =>
        GetLocationByName(exit.Name)
            .Exits
            .OrderBy(o => o.Value.Name)
            .Skip(Random.Next(0, exit.ExitList.Count()))
            .First().Value;
}
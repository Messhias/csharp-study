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
        var livingRoom = new LocationWithHidingPlace("Living Room", "behind the sofa");
        var kitchen = new LocationWithHidingPlace("Kitchen", "next to the stove");
        var bathroom = new LocationWithHidingPlace("Bathroom", "behind the door");
        var landing = new Location("Landing");
        var masterBedroom = new LocationWithHidingPlace("Master Bedroom", "in the closet");
        var masterBath = new LocationWithHidingPlace("Master Bath", "in the bathtub");
        var secondBathroom = new LocationWithHidingPlace("Second Bathroom", "in the shower");
        var kidsRoom = new LocationWithHidingPlace("Kids Room", "under the bed");
        var nursery = new LocationWithHidingPlace("Nursery", "under the crib");
        var pantry = new LocationWithHidingPlace("Pantry", "inside a cabinet");
        var attic = new LocationWithHidingPlace("Attic", "in a trunk");
        var garage = new LocationWithHidingPlace("Garage", "behind the car");

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

    public static void ClearHidingPlaces()
    {
        foreach (var location in Locations)
        {
            if (location is LocationWithHidingPlace locationWithHidingPlace)
            {
                locationWithHidingPlace.CheckHidingPlace();
            }
        }
    }
}
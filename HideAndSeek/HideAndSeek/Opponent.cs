using System.Diagnostics;

namespace HideAndSeek;

public class Opponent(string name)
{
    public readonly string Name = name;
    private LocationWithHidingPlace? _hideout;

    public override string ToString()
    {
        return Name;
    }

    public bool CheckHidingPlace(Location check)
    {
        return _hideout == check;
    }

    public Location Hide()
    {
        var currentLocation = House.Entry;

        var locationsToMoveThrough = House.Random.Next(10, 20);

        for (var i = 0; i < locationsToMoveThrough; i++)
            currentLocation = House.RandomExit(currentLocation);

        while (!(currentLocation is LocationWithHidingPlace)) currentLocation = House.RandomExit(currentLocation);

        (currentLocation as LocationWithHidingPlace).Hide(this);

        _hideout = currentLocation as LocationWithHidingPlace;

        Debug.WriteLine(
            $"{Name} is hiding {(currentLocation as LocationWithHidingPlace).HidingPlace} in the {currentLocation.Name}");

        return _hideout;
    }
}
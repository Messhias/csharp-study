namespace HideAndSeek;

public class LocationWithHidingPlace(string name, string hidingLocation) : Location(name)
{
    private readonly List<Opponent> _hiders = new();
    
    public void Hide(Opponent opponent) => _hiders.Add(opponent);

    public string HidingPlace { get; set; } = hidingLocation;

    public List<Opponent> CheckHidingPlace()
    {
        var foundOpponents = new List<Opponent>(_hiders);
        _hiders.Clear();
        return foundOpponents;
    }

    public override string ToString() => Name;
}
namespace HideAndSeek;

public class GameController
{
    /// <summary>
    ///     Private list of opponents the player has found so far
    /// </summary>
    private readonly List<Opponent> _foundOpponents = new();

    /// <summary>
    ///     Private list of opponents the player needs to find
    /// </summary>
    public readonly IEnumerable<Opponent> Opponents = new List<Opponent>
    {
        new("Joe"),
        new("Bob"),
        new("Ana"),
        new("Owen"),
        new("Jimmy")
    };

    public GameController()
    {
        House.ClearHidingPlaces();
        foreach (var opponent in Opponents) opponent.Hide();
        CurrentLocation = House.Entry;
    }

    /// <summary>
    ///     The number of moves the player has made
    /// </summary>
    public int MoveNumber { get; private set; } = 1;

    /// <summary>
    ///     Returns true if the game is over
    /// </summary>
    public bool GameOver => Opponents.Count() == _foundOpponents.Count();

    /// <summary>
    ///     The player's current location in the house
    /// </summary>
    public Location CurrentLocation { get; private set; }

    /// <summary>
    ///     Returns the current status to show to the player
    /// </summary>
    public string Status => $"You are in the {CurrentLocation}. You see the following exits:" +
                            Environment.NewLine +
                            $" - {string.Join(Environment.NewLine + " - ", CurrentLocation.ExitList)}";

    /// <summary>
    ///     A prompt to display to the player
    /// </summary>
    public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

    /// <summary>
    ///     Move to the location in a direction
    /// </summary>
    /// <param name="direction">The direction to move</param>
    /// <returns>True if the player can move in that direction, false oterwise</returns>
    public bool Move(Direction direction)
    {
        var nextLocation = CurrentLocation.GetExit(direction);

        if (nextLocation == CurrentLocation) return false;

        CurrentLocation = nextLocation;

        return true;
    }

    /// <summary>
    ///     Parses input from the player and updates the status
    /// </summary>
    /// <param name="input">Input to parse</param>
    /// <returns>The results of parsing the input</returns>
    public string ParseInput(string input)
    {
        var results = "That's not a valid direction";

        if (input.ToLower().StartsWith("save "))
        {
            var filename = input.Substring(5);
            results = Save(filename);
        }
        else if (input.ToLower().StartsWith("load "))
        {
            var filename = input.Substring(5);
            results = Load(filename);
        }
        else if (input.ToLower() == "check")
        {
            MoveNumber++;
            if (CurrentLocation is LocationWithHidingPlace locationWithHidingPlace)
            {
                var found = locationWithHidingPlace.CheckHidingPlace();
                if (found.Count() == 0)
                    results = $"Nobody was hiding {locationWithHidingPlace.HidingPlace}";
                else
                {
                    _foundOpponents.AddRange(found);
                    var s = found.Count() == 1 ? "" : "s";
                    results = $"You found {found.Count()} opponent{s} hiding {locationWithHidingPlace.HidingPlace}";
                }
            }
            else
            {
                results = $"There is no hiding place in the {CurrentLocation}";
            }
        }

        else if (Enum.TryParse(typeof(Direction), input, out object direction))
        {
            if (!Move((Direction)direction))
                results = "There's no exit in that direction";
            else
            {
                MoveNumber++;
                results = $"Moving {direction}";
            }
        }
        return results;
    }

    private string Load(string filename)
    {
        throw new NotImplementedException();
    }

    public string Save(string filename)
    {
        throw new NotImplementedException();
    }
}
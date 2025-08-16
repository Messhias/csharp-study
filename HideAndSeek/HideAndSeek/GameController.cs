namespace HideAndSeek;

public class GameController
{
    /// <summary>
    /// The number of moves the player has made
    /// </summary>
    public int MoveNumber { get; private set; } = 1;
    
    /// <summary>
    /// Private list of opponents the player needs to find
    /// </summary>
    public readonly IEnumerable<Opponent> Opponents = new List<Opponent>
    {
        new("Joe"),
        new("Bob"),
        new("Ana"),
        new("Owen"),
        new("Jimmy"),
    };
    
    /// <summary>
    /// Private list of opponents the player has found so far
    /// </summary>
    private readonly List<Opponent> _foundOpponents = new();

    /// <summary>
    /// Returns true if the game is over
    /// </summary>
    public bool GameOver => Opponents.Count() == _foundOpponents.Count();
    
    /// <summary>
    /// The player's current location in the house
    /// </summary>
    public Location CurrentLocation { get; private set; }

    /// <summary>
    /// Returns the current status to show to the player
    /// </summary>
    public string Status => $"You are in the {CurrentLocation}. You see the following exits:" +
                            Environment.NewLine +
                            $" - {string.Join(Environment.NewLine + " - ", CurrentLocation.ExitList)}";
    /// <summary>
    /// A prompt to display to the player
    /// </summary>
    public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

    public GameController()
    {
        House.ClearHidingPlaces();
        foreach (var opponent in Opponents)
        {
            opponent.Hide();
        }
        CurrentLocation = House.Entry;
    }

    /// <summary>
    /// Move to the location in a direction
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
    /// Parses input from the player and updates the status
    /// </summary>
    /// <param name="input">Input to parse</param>
    /// <returns>The results of parsing the input</returns>
    public string ParseInput(string input)
    {
        string result;
        if (Enum.TryParse(input, true, out Direction direction))
        {
            result = !Move(direction) ? "There's no exit in that direction" : $"Moving {direction}";
        }
        else
        {
            result = "That's not a valid direction";
        }

        return result;
    }
}
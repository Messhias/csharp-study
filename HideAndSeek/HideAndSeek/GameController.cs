namespace HideAndSeek;

public class GameController
{
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
    public string Prompt => "Which direction do you want to go: ";

    public GameController()
    {
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
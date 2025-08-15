namespace HideAndSeek;

public class GameController
{
    Location CurrentLocation { get; set; }
    public string Status;
    public string Prompt;

    public bool Move(Direction direction)
    {
        return false;
    }

    public string ParseInput(string input)
    {
        return "";
    }
}
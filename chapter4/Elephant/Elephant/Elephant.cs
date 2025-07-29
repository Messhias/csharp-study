namespace Elephant;

public class Elephant
{
    public string Name;
    public int EarSize;

    public string WhoIAm() => $"My name is {Name}. \nMy ears size {EarSize} tall.";

    public string HearMessage(string message, Elephant whoSaidIt) => $"{Name} heard a message." +
                                                                     $"\n {whoSaidIt.Name} said this: {message}";

    public string SpeakTo(Elephant whoToTalkTo, string message) => whoToTalkTo.HearMessage(message, this);
}
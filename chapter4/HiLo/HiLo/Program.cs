// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to HiLo!");

Console.WriteLine($"Guess a number between 1 and {HiLoGame.MAXIMUM}");
HiLoGame.Hint();

while (HiLoGame.GetPot() > 0)
{
    Console.WriteLine("Press H for higher, L for lower, ? to buy a hint");
    Console.WriteLine($"or any other key to quite with {HiLoGame.GetPot()}");
    var key = Console.ReadKey(true).KeyChar;

    switch (key.ToString().ToLower())
    {
        case "h":
            HiLoGame.Guess(true);
            break;
        case "l":
            HiLoGame.Guess(false);
            break;
        case "?":
            HiLoGame.Hint();
            break;
        default:
            return;
    }
}

Console.WriteLine("The pot is empty. Bye.");

internal static class HiLoGame
{
    public const int MAXIMUM = 10;
    private static readonly Random Random = new();
    private static int _currentNumber = Random.Next(1, MAXIMUM + 1);
    private static int _pot = 10;

    public static void Guess(bool higher)
    {
        var next = Random.Next(1, MAXIMUM + 1);

        if ((higher && next >= _currentNumber) || (!higher && next <= _currentNumber))
        {
            Console.WriteLine("You guessed right");
            _pot++;
        }
        else
        {
            Console.WriteLine("You guessed wrong");
            _pot--;
        }

        _currentNumber = next;
        Console.WriteLine($"The current number is {_currentNumber}");
    }

    public static void Hint()
    {
        const int halfMaximum = MAXIMUM / 2;
        string tip;

        tip = halfMaximum >= _currentNumber ? 
            $"he humber is at least {halfMaximum}" : $"The number is at most {halfMaximum}";

        _pot--;
        Console.WriteLine(tip);
    }

    public static int GetPot()
    {
        return _pot;
    }
}
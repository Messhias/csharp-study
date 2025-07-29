namespace AbilityScoreTest;

public class AbilityScoreCalculator
{
    public int RollResult = 14;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;
    public double DividedBy = 1.75;

    public void CalculateAbilityScore()
    {
        var divided = RollResult / DividedBy;
        
        var added = AddAmount + (int)divided;

        Score = added < Minimum ? Minimum : added;
    }

    public void RunSoftware()
    {
        while (true)
        {
            RollResult = ReadInt(RollResult, "Starting 4d6 result");
            DividedBy = ReadDouble(DividedBy, "Divided by");
            AddAmount =  ReadInt(AddAmount, "Add amount");
            Minimum =  ReadInt(Minimum, "Minimum");
            CalculateAbilityScore();
    
            Console.WriteLine($"The ability score is {Score}");
    
            Console.WriteLine("Press Q to quit");
            char key = Console.ReadKey(true).KeyChar;
            if (key is 'Q' or 'q') return;
        }
    }
    
    static int ReadInt(int lastUsedValue, string prompt)
    {
        Console.Write($"{prompt} [{lastUsedValue}]: ");
        string line = Console.ReadLine();

        if (int.TryParse(line, out int result))
        {
            Console.WriteLine($" using value {result}");
            return result;
        }

        Console.WriteLine($"Using default value {lastUsedValue}");
        return lastUsedValue;
    }

    static double ReadDouble(double lastUsedValue, string prompt)
    {
        Console.Write($"{prompt} [{lastUsedValue}]: ");
        string line = Console.ReadLine();

        if (double.TryParse(line, out double result))
        {
            Console.WriteLine($" using value {result}");
            return result;
        }

        Console.WriteLine($"Using default value {lastUsedValue}");
        return lastUsedValue;
    }
}
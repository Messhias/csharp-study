namespace Casino;

public class Player
{
    public required string Name;
    public int Cash;

    /// <summary>
    /// Wrote down statement
    /// </summary>
    public void WriteMyInfo()
    {
        Console.WriteLine($"Name: {Name}, Cash: {Cash}");
    }

    /// <summary>
    /// Give cash to someone.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public int GiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"{Name} says: {amount} isn't valid amount.");
            return 0;
        }

        if (amount > Cash)
        {
            Console.WriteLine($"{Name} says: {amount}... I do not have enough cash.");
            return 0;
        }
        
        Cash -= amount;
        return amount;
    }

    /// <summary>
    /// Receive cash from someone.
    /// </summary>
    /// <param name="amount"></param>
    public void ReceiveCash(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"{Name} says: {amount} isn't valid amount. I'll take you back.");
            return;
        }
        
        Cash += amount;
    }
}
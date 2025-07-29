// See https://aka.ms/new-console-template for more information

using JoeBob;

Console.WriteLine("Hello, World!");

var joe = new Guy{
    Name = "Joe",
    Cash = 50,
};

var bob = new Guy
{
    Name = "Bob",
    Cash = 150,
};

while (true)
{
    Console.WriteLine("Enter an amount: ");
    string howMuch = Console.ReadLine();

    if (howMuch == "")
    {
        Console.WriteLine("You need to enter an amount!");
        return;
    }

    if (int.TryParse(howMuch, out var money))
    {
        Console.WriteLine("Who's going to receive money?");
        var whichGuy = Console.ReadLine();

        int result = 0;
        switch (whichGuy)
        {
            case "Joe":
                result = joe.GiveCash(money);
                bob.ReceiveCash(result);
                break;  
            case "Bob":
                result = bob.GiveCash(money);
                joe.ReceiveCash(result);
                break;
            default:
                Console.WriteLine("You need to inform if it's Joe or Bob.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Please amount or blank line to exit.");   
    }
}
// See https://aka.ms/new-console-template for more information

using Casino;


var random = new Random();
const double odds = 0.75;
var player = new Player()
{
    Name = "Player",
    Cash =   100,
};

while (player.Cash > 0)
{
    // Console.Clear();
    Console.WriteLine("--------");
    Console.WriteLine("Please enter a valid number");
    Console.WriteLine("--------");
    
    player.WriteMyInfo();
    
    Console.WriteLine("What's your bet?");
    var howMuch = Console.ReadLine();
    if (int.TryParse(howMuch, out var amount))
    {
        var pot = player.GiveCash(amount) * 2;
        if (pot > 0)
        {
            if (random.NextDouble() > odds)
            {
                Console.WriteLine($"You win {pot}");
                player.ReceiveCash(pot);
            }
            else
            {
                Console.WriteLine("Bad luck, you lose.");
            }
        }
    }
}
Console.WriteLine("House always wins.");
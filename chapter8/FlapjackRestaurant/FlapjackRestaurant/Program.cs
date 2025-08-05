Random random = new Random();
Queue<Lumberjack> lumberjacks = new Queue<Lumberjack>();

string name;

    Console.WriteLine("1º Lumberjack's name");
while ((name = Console.ReadLine()) != "")
{
    Console.WriteLine("Number of flapjacks");

    if (int.TryParse(Console.ReadLine(), out int num))
    {
        Lumberjack lumberjack = new Lumberjack(name);
        for (int i = 0; i < num; i++)
        {
            lumberjack.TakeFlapjack((FlapJack)random.Next(0, 4));
        }
        lumberjacks.Enqueue(lumberjack);
    }

    Console.WriteLine("Next Lumberjack's name");
}

while (lumberjacks.Count > 0)
{
    Lumberjack next =  lumberjacks.Dequeue();
    next.EatFlapjacks();
}
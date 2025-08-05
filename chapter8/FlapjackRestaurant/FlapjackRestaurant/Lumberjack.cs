public class Lumberjack
{
    public string Name { get; set; }
    private Stack<FlapJack> _lumberjacks = new Stack<FlapJack>();

    public Lumberjack(string name)
    {
        Name = name;
    }

    public void TakeFlapjack(FlapJack lumberjack)
    {
        _lumberjacks.Push(lumberjack);
    }

    public void EatFlapjacks()
    {
        while (_lumberjacks.Count > 0)
        {
            Console.WriteLine($"{Name} ate {_lumberjacks.Pop().ToString().ToLower()} flapjacks");
        }
    }
}

public enum FlapJack     
{
    Crispy,
    Soggy,
    Browned,
    Banana,
}
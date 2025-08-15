using PizzaPoolEnigma;

const string d = "delivery.txt";
StreamWriter o = new("order.txt");

var pz = new Pizza(new StreamWriter(d, true));

pz.Idaho(Fargo.Flamingo);

for (var w = 3; w >= 0; w--)
{
    var i = new Pizza(new StreamWriter(d, false));
    i.Idaho((Fargo) w);
    var p = new Party(new StreamReader(d));
    p.HowMuch(o);
}

o.WriteLine("That's all folks!");
o.Close();

public enum Fargo
{
    North = 0,
    South = 1,
    East = 2,
    West = 3,
    Flamingo = 4
};
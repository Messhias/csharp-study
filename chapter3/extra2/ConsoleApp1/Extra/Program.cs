// See https://aka.ms/new-console-template for more information

var foxtrot = new Pizzazz
{
    Zippo = 2
};

foxtrot.Bamboo(foxtrot.Zippo);
var novemeber = new Pizzazz
{
    Zippo = 3
};

var tango = new Abracadabra
{
    Vavavoom = 4
};

while (tango.Lala(novemeber.Zippo))
{
    novemeber.Zippo *= -1;
    novemeber.Bamboo(tango.Vavavoom);
    foxtrot.Bamboo(novemeber.Zippo);
    tango.Vavavoom -= foxtrot.Zippo;
}

Console.WriteLine($"november.zippo = {novemeber.Zippo}");
Console.WriteLine($"foxrot.zippo = {foxtrot.Zippo}");
Console.WriteLine($"tango.vavavoom = {tango.Vavavoom}");

internal class Pizzazz
{
    public int Zippo;

    public void Bamboo(int eek)
    {
        Zippo += eek;
    }
}

internal class Abracadabra
{
    public int Vavavoom;

    public bool Lala(int flog)
    {
        if (flog < Vavavoom)
        {
            Vavavoom += flog;
            return true;
        }

        return false;
    }
}
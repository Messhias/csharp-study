﻿Animal[] animals =
[
    new Wolf(false),
    new Hippo(),
    new Wolf(true),
    new Wolf(false),
    new Hippo(),
];

foreach (Animal animal in animals)
{
    animal.MakeNoise();
    if (animal is ISwimmer swimmer)
    {
        swimmer.Swim();
    }

    if (animal is IPackHunter packHunter)
    {
        packHunter.HuntInPack();
    }

    Console.WriteLine();
}

interface ISwimmer
{
    void Swim();
}

interface IPackHunter
{
    void HuntInPack();
}

abstract class Animal
{
    public abstract void MakeNoise();
}

class Hippo : Animal, ISwimmer
{
    public override void MakeNoise()
    {
        Console.WriteLine("Grunt!");
    }

    public void Swim()
    {
        Console.WriteLine("Splash! I'm going for a swim.");
    }
}

abstract class Canine : Animal
{
    public bool BelongsToPack { get; protected set; } = false;
}

class Wolf : Canine, IPackHunter
{
    public Wolf(bool belongsToPack)
    {
        BelongsToPack = belongsToPack;
    }

    public override void MakeNoise()
    {
        if (BelongsToPack)
        {
            Console.Write("I'm in a pack.");
        }

        Console.WriteLine("Arooooo!");
    }

    public void HuntInPack()
    {
        if (BelongsToPack)
        {
            Console.WriteLine("I'm going hunting with my pack!");
        }
        else
        {
            Console.WriteLine("I'm not in a pack.");
        }
    }
}
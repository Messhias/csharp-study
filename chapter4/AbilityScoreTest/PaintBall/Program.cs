Console.WriteLine("How many bullets?");
int.TryParse(Console.ReadLine(), out int bullets);

Console.WriteLine("Magazine size?");
int.TryParse(Console.ReadLine(), out int magazineSize);

Console.WriteLine("Is loaded [defualt is false]?");
bool.TryParse(Console.ReadLine(), out bool loaded);

PaintBallGun gun = new PaintBallGun(bullets, magazineSize, loaded);

while (true)
{
    Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
    if (gun.IsEmpty())
    {
        Console.WriteLine("WARNING, you are out of ammo.");
    }

    Console.WriteLine("Space to shoot, r to reaload, + to add ammo, q to quit");
    char key = Console.ReadKey(true).KeyChar;

    switch (key)
    {
        case 'q':
            return;

        case ' ':
            Console.WriteLine($"Shooting returned {gun.Shoot()}");
            break;

        case 'r':
            gun.Reload();
            break;

        case '+':
            gun.Balls += PaintBallGun.MagazineSize;
            break;
    }
}

internal class PaintBallGun
{
    private int _balls;

    public int Balls
    {
        get => _balls;
        set
        {
            if (value > 0)
            {
                _balls = value;
            }

            Reload();
        }
    }

    public int BallsLoaded { get; private set; }

    public static int MagazineSize { get; private set; } = 16;


    public PaintBallGun(int balls, int magazineSize, bool isLoaded = false)
    {
        MagazineSize = magazineSize;
        Balls = balls;
        if (isLoaded) Reload();
    }

    public bool IsEmpty() => BallsLoaded == 0;

    public void Reload()
    {
        BallsLoaded = _balls > MagazineSize ? MagazineSize : _balls;
    }

    public bool Shoot()
    {
        if (BallsLoaded == 0)
        {
            return false;
        }

        BallsLoaded--;
        _balls--;

        return true;
    }
}
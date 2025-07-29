namespace AbilityScoreTest;

public class SwordDamage
{
    private const int BASE_DAMAGE = 10;
    private const int FLAME_DAMAGE = 10;

    public int Damage { get; private set; }

    private int _roll;

    public int Roll
    {
        get { return _roll; }
        set
        {
            _roll = value;
            CalculateDamage();
        }
    }

    private bool _magic;

    public bool Magic
    {
        get { return _magic; }
        set
        {
            _magic = value;
            CalculateDamage();
        }
    }

    private bool _flaming;

    public bool Flaming
    {
        get { return _flaming; }
        set
        {
            _flaming = value;
            CalculateDamage();
        }
    }

    private void CalculateDamage()
    {
        decimal magicMultiplier = 1M;
        if (Magic) magicMultiplier = 1.7M;

        Damage = BASE_DAMAGE;
        Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;

        if (Flaming)
        {
            Damage += FLAME_DAMAGE;
        }
    }

    public SwordDamage(int roll)
    {
        _roll = roll;
        CalculateDamage();
    }

    public override string ToString() => $"Rolled: {Roll} for {Damage} HP";
}
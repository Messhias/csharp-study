namespace AbilityScoreTest;

public class ArrowDamage
{
    private const decimal BASE_MULTIPLIER = 0.35M;
    private const decimal MAGIC_DAMAGE = 2.5M;
    private const decimal FLAME_DAMAGE = 1.25M;

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
        decimal baseDamage = Roll * BASE_MULTIPLIER;
        
        if (Magic) baseDamage *= MAGIC_DAMAGE;
        if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
        else Damage = (int)Math.Floor(baseDamage);
    }

    public ArrowDamage(int roll)
    {
        _roll = roll;
        CalculateDamage();
    }

    public override string ToString() => $"Rolled: {Roll} for {Damage} HP";
}
namespace AbilityScoreTest;

abstract public class WeaponDamage
{
    public int Damage { get; protected set; }
    
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

    protected abstract void CalculateDamage();

    public WeaponDamage(int roll)
    {
        _roll = roll;
        CalculateDamage();
    }
}
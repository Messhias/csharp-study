namespace AbilityScoreTest;

public class SwordDamage : WeaponDamage
{
    private const int BASE_DAMAGE = 10;
    private const int FLAME_DAMAGE = 10;

    protected override void CalculateDamage()
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

    public SwordDamage(int roll) : base(roll)
    {
        CalculateDamage();
    }

    public override string ToString() => $"Rolled: {Roll} for {Damage} HP";
}
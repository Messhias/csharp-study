namespace AbilityScoreTest;

public class ArrowDamage : WeaponDamage
{
    private const decimal BASE_MULTIPLIER = 0.35M;
    private const decimal MAGIC_DAMAGE = 2.5M;
    private const decimal FLAME_DAMAGE = 1.25M;

    protected override void CalculateDamage()
    {
        decimal baseDamage = Roll * BASE_MULTIPLIER;
        
        if (Magic) baseDamage *= MAGIC_DAMAGE;
        if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
        else Damage = (int)Math.Floor(baseDamage);
    }

    public ArrowDamage(int roll) : base(roll)
    {
        CalculateDamage();
    }

    public override string ToString() => $"Rolled: {Roll} for {Damage} HP";
}
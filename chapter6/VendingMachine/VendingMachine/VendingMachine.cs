namespace VendingMachine;

public class VendingMachine
{
    public virtual string Item { get; }

    protected virtual bool CheckAmount(decimal money)
    {
        return false;
    }

    public string Dispense(decimal money)
    {
        if (CheckAmount(money))
        {
            return Item;
        }

        return "Invalid amount";
    }
}

class AnimalFeedVendingMachine : VendingMachine
{
    public override string Item { get; } = "a handful of animal feed";

    protected override bool CheckAmount(decimal money)
    {
        return money >= 1.25M;
    }
}
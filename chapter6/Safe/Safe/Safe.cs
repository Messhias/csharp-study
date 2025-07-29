namespace Safe;

public class Safe
{
    private readonly string _contents = "precious jewels";
    private readonly string _safeCombination = "12345";

    public string Open(string combination)
    {
        if (combination == _safeCombination) return _contents;

        return "";
    }

    public void PickLock(Locksmith lockpicker)
    {
        lockpicker.Combination = _safeCombination;
    }
}

public class Locksmith
{
    public void OpenSafe(Safe safe, SafeOwner owner)
    {
        safe.PickLock(this);
        string safeContents = safe.Open(Combination);
        ReturnContents(safeContents, owner);
    }

    public string Combination { get; set; } = "";

    protected virtual void ReturnContents(string contents, SafeOwner owner)
    {
        owner.ReceiveContents(contents);
    }
}

public class SafeOwner
{
    private string valuables = "";


    public void ReceiveContents(string safeContents)
    {
        valuables = safeContents;
        Console.WriteLine($"Thank you for returning my {valuables}");
    }
}

public class JewelThief : Locksmith
{
    private string stolenJewels = "";

    protected override void ReturnContents(string safeContents, SafeOwner owner)
    {
        stolenJewels = safeContents;
        Console.WriteLine($"Stole {stolenJewels}");
    }
}
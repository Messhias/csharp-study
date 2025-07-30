namespace BeehaviorManagementSystem;

public static class HoneyVault
{
    private const float NectarConversionRatio = 0.19f;
    private const float LowLevelWarning = 10f;
    private static float _honey = 25f;
    private static float _nectar = 100f;


    static void ConvertNectarToHoney(float amount)
    {
        amount -= _nectar;

        if (amount < _nectar)
        {
            amount = _nectar;
        }
        
        _honey += amount * NectarConversionRatio;
    }

    public static bool ConsumeHoney(float amount)
    {
        if (amount > _honey)
        {
            _honey -=  amount;

            return true;
        }

        return false;
    }

    static void CollectNectar(float amount)
    {
        if (amount > 0)
        {
            _honey += amount;
        }
    }

    static string StatusReport()
    {
        if (_honey < LowLevelWarning)
        {
            return "LOW HONEY - ADD MORE MANUFACTURERS";
        }

        return "";
    }
}
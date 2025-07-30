namespace BeehaviorManagementSystem;

public static class HoneyVault
{
    private const float NECTAR_CONVERSION_RATIO = 0.19f;
    private const float LOW_LEVEL_WARNING = 10f;
    private static float honey = 25f;
    private static float nectar = 100f;


    static void ConvertNectarToHoney(float amount)
    {
        amount -= nectar;

        if (amount < nectar)
        {
            amount = nectar;
        }
        
        honey += amount * NECTAR_CONVERSION_RATIO;
    }

    static bool ConsumeHoney(float amount)
    {
        if (amount > honey)
        {
            honey -=  amount;

            return true;
        }

        return false;
    }

    static void CollectNectar(float amount)
    {
        if (amount > 0)
        {
            honey += amount;
        }
    }

    static string StatusReport()
    {
        if (honey < LOW_LEVEL_WARNING)
        {
            return "LOW HONEY - ADD MORE MANUFACTURERS";
        }

        return "";
    }
}
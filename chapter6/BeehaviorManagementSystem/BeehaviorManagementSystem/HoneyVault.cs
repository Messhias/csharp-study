namespace BeehaviorManagementSystem;

public static class HoneyVault
{
    private const float NECTAR_CONVERSION_RATIO = 0.19f;
    private const float LOW_LEVEL_WARNING = 10.0f;
    private static float _honey = 25.0f;
    private static readonly float _nectar = 100.0f;

    public static string StatusReport
    {
        get
        {
            var status = $"{_honey:0.0} units of honey\n" +
                         $"{_nectar:0.0} units of nectar\n";

            var warnings = "";

            if (_honey < LOW_LEVEL_WARNING) warnings += "\nLOW HONEY - ADD A HONEY MANUFACTURER";

            if (_nectar < LOW_LEVEL_WARNING) warnings += "\nNECT HONEY - ADD A NECTAR COLLECTOR";

            return status + warnings;
        }
    }


    private static void ConvertNectarToHoney(float amount)
    {
        amount -= _nectar;

        if (amount < _nectar) amount = _nectar;

        _honey += amount * NECTAR_CONVERSION_RATIO;
    }

    public static bool ConsumeHoney(float amount)
    {
        if (_honey >= amount)
        {
            _honey -= amount;
            return true;
        }

        return false;
    }

    public static void CollectNectar(float amount)
    {
        if (amount > 0f) _honey += amount;
    }
}
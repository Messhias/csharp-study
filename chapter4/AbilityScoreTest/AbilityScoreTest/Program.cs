// See https://aka.ms/new-console-template for more information

// using AbilityScoreTest;
//
// AbilityScoreCalculator abilityScoreCalculator = new AbilityScoreCalculator();
//
// abilityScoreCalculator.RunSoftware();

using AbilityScoreTest;


while (true)
{

    Console.WriteLine("===============");
    Console.WriteLine("Choose your weapon, A to arrow, S to sword");
    string weapon = Console.ReadKey(true).KeyChar.ToString().ToUpper();

    switch (weapon)
    {
        case "A":
            ArrowRoll();
            break;
        case "S":
            SwordRoll();
            break;
        default: return;
    }
    
    Console.WriteLine("===============");
}


void SwordRoll()
{
    var roll = DiceRoll();
    SwordDamage damage = new SwordDamage(roll);

    int option;
    
    Console.WriteLine("Selection option:" +
                      " 0 - no magic/flaming. 1 - magic. 2 - flaming. 3 - both. Anything else to quit");

    option = Console.ReadKey(true).KeyChar;

    switch (option)
    {
        case '0':
            break;
        case '1':
            damage.Magic = true;
            break;
        case '2':
            damage.Magic = false;
            damage.Flaming = true;
            break;
        case '3':
            damage.Magic = true;
            damage.Flaming = true;
            break;
        default:
            return;
    }
    
    Console.WriteLine(damage.ToString());
}

void ArrowRoll()
{
    var roll = DiceRoll(1);
    ArrowDamage damage = new ArrowDamage(roll);

    int option;
    
    Console.WriteLine("Selection option:" +
                      " 0 - no magic/flaming. 1 - magic. 2 - flaming. 3 - both. Anything else to quit");

    option = Console.ReadKey(true).KeyChar;

    switch (option)
    {
        case '0':
            break;
        case '1':
            damage.Magic = true;
            break;
        case '2':
            damage.Magic = false;
            damage.Flaming = true;
            break;
        case '3':
            damage.Magic = true;
            damage.Flaming = true;
            break;
        default:
            return;
    }
    
    Console.WriteLine(damage.ToString());
}


 static int DiceRoll(int numberOfRolls = 3, int diceSides = 7)
{
    var random = new Random();
    var roll1 = 0;

    for (var i = 0; i < numberOfRolls; i++)
    {
        roll1 += random.Next(1, diceSides);
    }

    return roll1;
}
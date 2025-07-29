// See https://aka.ms/new-console-template for more information

using Elephant;

// Elephant.Elephant lloyd = new Elephant.Elephant()
// {
//     Name = "Lloyd",
//     EarSize = 40,
// };
// Elephant.Elephant lucinda = new Elephant.Elephant()
// {
//     Name = "Lucinda",
//     EarSize = 33,
// };

// while (true)
// {
//     Elephant.Elephant? swap;
//     Console.WriteLine("-------------------");
//     Console.WriteLine("1 - LLoyd.\n" +
//                       "2 - Lucinda.\n" +
//                       "3 - Swap.\n" +
//                       "4 - mess up with references.\n" +
//                       "Q - Exit");
//     string? key = Console.ReadLine();
//
//     if (int.TryParse(key, out int keyInt))
//     {
//         switch (keyInt)
//         {
//             case 1:
//                 Console.WriteLine(lloyd.WhoIAm());
//                 break;
//             case 2:
//                 Console.WriteLine(lucinda.WhoIAm());
//                 break;
//             case 3:
//                 swap = lloyd;
//                 lloyd = lucinda;
//                 lucinda = swap;
//
//                 Console.WriteLine(lucinda.WhoIAm());
//                 Console.WriteLine(lloyd.WhoIAm());
//
//                 break;
//             case 4:
//                 lloyd = lucinda;
//                 lloyd.EarSize = 999999;
//                 Console.WriteLine(lloyd.WhoIAm());
//                 break;
//             case 5:
//                 Console.WriteLine(lucinda.SpeakTo(lloyd, "Hi, Lloyd"));
//                 break;
//             default:
//                 Console.WriteLine("Wrong option.");
//                 break;
//         }
//     }
//     else if (key is "Q" or "q")
//     {
//         return;
//     }
//
//     Console.WriteLine("-------------------");
// }

Elephant.Elephant[] elephants = new Elephant.Elephant[7];
elephants[0] = new Elephant.Elephant()
{
    Name = "1",
    EarSize =40,
};

elephants[1] = new Elephant.Elephant()
{
    Name = "2",
    EarSize = 33,
};

elephants[2] = new Elephant.Elephant()
{
    Name = "3",
    EarSize = 42,
};

elephants[3] = new Elephant.Elephant()
{
    Name = "4",
    EarSize = 32,
};

elephants[4] = new Elephant.Elephant()
{
    Name = "5",
    EarSize = 44,
};

elephants[5] = new Elephant.Elephant()
{
    Name = "6",
    EarSize = 37,
};

elephants[6] = new Elephant.Elephant()
{
    Name = "7",
    EarSize = 45,
};

Elephant.Elephant biggestEars = elephants[0];

for (int i = 0; i < elephants.Length; i++)
{
    Console.WriteLine($"Interaction {i}");

    if (elephants[i].EarSize > biggestEars.EarSize)
    {
        biggestEars = elephants[i];
    }
    
    Console.WriteLine(biggestEars.EarSize);
}
// See https://aka.ms/new-console-template for more information

using Safe;

SafeOwner owner = new SafeOwner();
var safe = new Safe.Safe();
JewelThief thief = new JewelThief();
thief.OpenSafe(safe, owner);
Console.ReadKey(true);

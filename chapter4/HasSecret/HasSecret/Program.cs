// See https://aka.ms/new-console-template for more information

using System.Reflection;

HasScecret keeper = new HasScecret();

FieldInfo[] fields = keeper.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

foreach (var field in fields)
{
    Console.WriteLine(field.GetValue(keeper));
}

class HasScecret
{
    private string secret = "XPTO";
}
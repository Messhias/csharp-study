
using System.Reflection;

var writer = new StreamWriter( "write.txt");

writer.WriteLine("Hi I'll defeat Captain Amazing");
writer.WriteLine("Another genius secret plan by The Swindler");
writer.WriteLine("I'll unleash my army of clones upn the citizens of Objectville.");
var location = "the mall";

for (var i = 0; i < 5; i++)
{
    writer.WriteLine("Clone #{0} attacks {1}", i, location);
    location = location == "the mall" ? "downtown" : "the mall";
}

writer.Close();

var executableLocation = Path.GetDirectoryName(
    Assembly.GetExecutingAssembly().Location);
var file = Path.Combine(executableLocation, "write.txt");

var reader = new StreamReader(file);
writer = new StreamWriter("emailToCaptainA.txt");

writer.WriteLine("To: CaptainA@objectville.net");
writer.WriteLine("From: Comissioner@objectville.net");
writer.WriteLine("Subject: Can you save the day...again?");
writer.WriteLine();
writer.WriteLine("We've discovered the Swindler's terrible plan.");

while (!reader.EndOfStream)
{
    var lineFromThePlan = reader.ReadLine();
    writer.WriteLine($"The plan -> {lineFromThePlan}");
}
writer.WriteLine();
writer.WriteLine("Can you help us?");

writer.Close();
reader.Close();
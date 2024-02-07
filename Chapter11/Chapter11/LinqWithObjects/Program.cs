// a string array is a sequence that implements IEnumerable<string>
using System.Linq;

string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
SectionTitle("Deferred execution");
// Question: Which names end with an M?
// (written using a LINQ extension method)
var query1 = names.Where(name => name.EndsWith("m"));
// Question: Which names end with an M?
// (written using LINQ query comprehension syntax)
var query2 = from name in names where name.EndsWith("m") select name;

// Answer returned as an array of strings containing Pam and Jim
string[] result1 = query1.ToArray();
// Answer returned as a list of strings containing Pam and Jim
List<string> result2 = query2.ToList();
//// Answer returned as we enumerate over the results
//foreach (string name in query1)
//{
//    WriteLine(name); 
//    names[2] = "Jimmy";
//}


SectionTitle("Writing queries");
var query = names
    .Where(n => n.Length > 4)
    .OrderBy(name => name.Length)
    .ThenBy(name => name);

foreach (string item in query)
{
    WriteLine(item);
}



//helpers
static void SectionTitle(string title)
{
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine("*");
    WriteLine($"* {title}");
    WriteLine("*");
    ForegroundColor = previousColor;
}

static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}
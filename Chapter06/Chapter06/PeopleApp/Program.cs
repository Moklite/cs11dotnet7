using Packt.Shared;
using System.Xml.Linq;

Person harry = new()
{
	Name = "Harry",
	DateOfBirth = new(year: 2001, month: 3, day: 25)
};
harry.WriteToConsole();

//// non-generic lookup collection
//System.Collections.Hashtable lookupObject = new();
//lookupObject.Add(key: 1, value: "Alpha");
//lookupObject.Add(key: 2, value: "Beta");
//lookupObject.Add(key: 3, value: "Gamma");
//lookupObject.Add(key: harry, value: "Delta");

//int key = 2; // look up the value that has 2 as its key

//WriteLine(format: "Key {0} has value: {1}",
// arg0: key,
// arg1: lookupObject[key]);

//// look up the value that has harry as its key
//WriteLine(format: "Key {0} has value: {1}",
// arg0: harry,
// arg1: lookupObject[harry]);

//// generic lookup collection
//Dictionary<int, string> lookupIntString = new();
//lookupIntString.Add(key: 1, value: "Alpha");
//lookupIntString.Add(key: 2, value: "Beta");
//lookupIntString.Add(key: 3, value: "Gamma");
//lookupIntString.Add(key: 4, value: "Delta");

//key = 3;
//WriteLine(format: "Key {0} has value: {1}",
// arg0: key,
// arg1: lookupIntString[key]);

// assign a method to the Shout delegate
//harry.Shout += Harry_Shout;
//harry.Shout += Harry_Shout2;
//// call the Poke method that raises the Shout event
//harry.Poke();
//harry.Poke();
//harry.Poke();
//harry.Poke();

//Person?[] people =
//{
// null,
// new() { Name = "Simon" },
// new() { Name = "Jenny" },
// new() { Name = "Adam" },
// new() { Name = null },
//  new() { Name = "Richard" }
//};
//OutputPeopleNames(people, "Initial list of people:");
//Array.Sort(people);
//OutputPeopleNames(people,
// "After sorting using Person's IComparable implementation:");

//DisplacementVector dv1 = new(3, 5);
//DisplacementVector dv2 = new(-2, 7);
//DisplacementVector dv3 = dv1 + dv2;
//WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X},{ dv3.Y})");
Employee john = new()
{
	Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.WriteToConsole();

john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

try
{
	john.TimeTravel(when: new(1999, 12, 31));
	john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
	WriteLine(ex.Message);
}
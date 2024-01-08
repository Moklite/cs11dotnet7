using Packt.Shared;
using System.Reflection.Metadata;
using Env = System.Environment;


//WriteLine(Env.OSVersion);
//WriteLine(Env.MachineName);
//WriteLine(Env.CurrentDirectory);

Person bob = new();
//WriteLine(bob.ToString());
bob.Name = "Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
bob.FavoriteAncientWonder =
 WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
//WriteLine(
// format: "{0}'s favorite wonder is {1}. Its integer is {2}.",
// arg0: bob.Name,
// arg1: bob.FavoriteAncientWonder,
// arg2: (int)bob.FavoriteAncientWonder);

//bob.BucketList =
// WondersOfTheAncientWorld.HangingGardensOfBabylon
// | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
//// bob.BucketList = (WondersOfTheAncientWorld)18;
//WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

//bob.Children.Add(new Person { Name = "Alfred" });
//bob.Children.Add(new () { Name = "Zoe" });

//WriteLine($"{bob.Name} has {bob.Children.Count} children");
//foreach (var item in bob.Children)
//{
//	WriteLine($"{item.Name}");
//}

//for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
//{
//	WriteLine($"> {bob.Children[childIndex].Name}");
//}

//Person alice = new()
//{
//	Name = "Alice Jones",
//	DateOfBirth = new(1998, 3, 7) // C# 9.0 or later
//};
//WriteLine(format: "{0} was born on {1:dd MMM yy}",
// arg0: alice.Name,
// arg1: alice.DateOfBirth);

//BankAccount.InterestRate = 0.012M; // store a shared value
//BankAccount jonesAccount = new();
//jonesAccount.AccountName = "Mrs. Jones";
//jonesAccount.Balance = 2400;
//WriteLine(format: "{0} earned {1:C} interest.",
// arg0: jonesAccount.AccountName,
// arg1: jonesAccount.Balance * BankAccount.InterestRate);

//BankAccount gerrierAccount = new();
//gerrierAccount.AccountName = "Ms. Gerrier";
//gerrierAccount.Balance = 98;
//WriteLine(format: "{0} earned {1:C} interest.",
// arg0: gerrierAccount.AccountName,
// arg1: gerrierAccount.Balance * BankAccount.InterestRate);

//WriteLine($"{bob.Name} is a {Person.Species}");
//WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

//Person blankPerson = new();
//WriteLine(format:
// "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
// arg0: blankPerson.Name,
// arg1: blankPerson.HomePlanet,
// arg2: blankPerson.Instantiated);

//Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
//WriteLine($"{gunny.Name} of {gunny.HomePlanet} was created at {gunny.Instantiated:hh:mm:ss} on {gunny.Instantiated:dddd}");

//bob.WriteToConsole();
//WriteLine(bob.GetOrigin());

//(string, int) fruit = bob.GetFruit();
//WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

//var fruitNamed = bob.GetNamedFruit();
//WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

//var thing1 = ("Neville", 4);
//WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
//var thing2 = (bob.Name, bob.Children.Count);
//WriteLine($"{thing2.Name} has {thing2.Count} children.");

//(string fruitName, int fruitNumber) = bob.GetFruit();
//WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

//var (name1, dob1) = bob;
//WriteLine($"Deconstructed: {name1}, {dob1}");

//var (name2, dob2, fav2) = bob;
//WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

//WriteLine(bob.SayHello());
//WriteLine(bob.SayHello("Emily"));

//WriteLine(bob.OptionalParameters());

//WriteLine(bob.OptionalParameters("Jump!", 98.5));

//WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));

//WriteLine(bob.OptionalParameters("Poke!", active: false));

//int a = 10;
//int b = 20;
//int c = 30;
//WriteLine($"Before: a = {a}, b = {b}, c = {c}");
//bob.PassingParameters(a, ref b, out c);
//WriteLine($"After: a = {a}, b = {b}, c = {c}");

//int d = 10;
//int e = 20;
//WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
//// simplified C# 7.0 or later syntax for the out parameter
//bob.PassingParameters(d, ref e, out int f);
//WriteLine($"After: d = {d}, e = {e}, f = {f}");

Person sam = new()
{
	Name = "Sam",
	DateOfBirth = new(1969, 6, 25)
};
//WriteLine(sam.Origin);
//WriteLine(sam.Greeting);
//WriteLine(sam.Age);

//sam.FavoriteIceCream = "Chocolate Fudge";
//WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
//string color = "Red";
//try
//{
//	sam.FavoritePrimaryColor = color;
//	WriteLine($"Sam's favorite primary color is {sam.
//   FavoritePrimaryColor}.");
//}
//catch (Exception ex)
//{
//	WriteLine("Tried to set {0} to '{1}': {2}",
//	nameof(sam.FavoritePrimaryColor), color, ex.Message);
//}

//Book book = new() 
//{
//	Isbn = "978-1803237800",
//	Title = "C# 11 and .NET 7 - Modern Cross-Platform Development Fundamentals"
//};

//WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
// book.Isbn, book.Title, book.Author, book.PageCount);

//Book book = new(isbn: "978-1803237800", title: "C# 11 and .NET 7 - Modern Cross-Platform Development Fundamentals")
//{
// Author = "Mark J. Price",
// PageCount = 821
//};

//Person lamech = new() { Name = "Lamech" };
//Person adah = new() { Name = "Adah" };
//Person zillah = new() { Name = "Zillah" };
//lamech.Marry(adah);
//Person.Marry(zillah, lamech);
//WriteLine($"{lamech.Name} is married to {lamech.Spouse?.Name ??
//"nobody"}");
//WriteLine($"{adah.Name} is married to {adah.Spouse?.Name ?? "nobody"}");
//WriteLine($"{zillah.Name} is married to {zillah.Spouse?.Name ??
//"nobody"}");
//// call instance method
//Person baby1 = lamech.ProcreateWith(adah);
//baby1.Name = "Jabal";
//WriteLine($"{baby1.Name} was born on {baby1.DateOfBirth}");
//// call static method
//Person baby2 = Person.Procreate(zillah, lamech);
//baby2.Name = "Tubalcain";
//WriteLine($"{lamech.Name} has {lamech.Children.Count} children.");
//WriteLine($"{adah.Name} has {adah.Children.Count} children.");
//WriteLine($"{zillah.Name} has {zillah.Children.Count} children.");

//for (int i = 0; i < lamech.Children.Count; i++)
//{
//	WriteLine(format: "{0}'s child #{1} is named \"{2}\".",
//	arg0: lamech.Name, arg1: i, arg2: lamech[i].Name);
//}

//int number = 5; // change to -1 to make the exception handling code execute
//try
//{
//	WriteLine($"{number}! is {Person.Factorial(number)}");
//}
//catch (Exception ex)
//{
//	WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}.");
//}

//Passenger[] passengers = {
// new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
// new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
// new BusinessClassPassenger { Name = "Janice" },
// new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
//  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
//};
//foreach (Passenger passenger in passengers)
//{
//	decimal flightCost = passenger switch
//	{
//		FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
//		FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
//		FirstClassPassenger _ => 2000M,
//		BusinessClassPassenger _ => 1000M,
//		CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
//		CoachClassPassenger _ => 650M,
//		_ => 800M
//	};
//	WriteLine($"Flight costs {flightCost:C} for {passenger}");
//}

ImmutablePerson jeff = new()
{
	FirstName = "Jeff",
	LastName = "Winger"
};
//jeff.FirstName = "Geoff";

ImmutableVehicle car = new()
{
	Brand = "Mazda MX-5 RF",
	Color = "Soul Red Crystal Metallic",
	Wheels = 4
};

ImmutableVehicle repaintedCar = car
 with
{ Color = "Polymetal Grey Metallic" };
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Brand}.");

ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // calls Deconstruct method
WriteLine($"{who} is a {what}.");
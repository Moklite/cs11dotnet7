string city = "London";
WriteLine($"{city} is {city.Length} characters long.");

WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array:");
foreach (var item in citiesArray)
{
	WriteLine(item);
}

string fullName = "Shore, Alan";
int index = fullName.IndexOf(",");
string firstName = fullName.Substring(startIndex: 0, length: index);
string lastName = fullName.Substring(startIndex: index + 2);
WriteLine($"{lastName} {firstName}");

string company = "Microsoft";
bool startsWithM = company.StartsWith("M");
bool containsN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");

string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;
WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}.");
WriteLine(string.Format("{0} cost {1:C} on {3:dddd}", arg0: fruit, arg1: price, arg2: when));
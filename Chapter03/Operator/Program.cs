int number = Random.Shared.Next(0, 7);
 WriteLine($"the random number is {number}");

string message = number switch
{
	0 => "The number is zero.",
	1 => "The number is one.",
	_ => "The number is out of range."
};
WriteLine(message);
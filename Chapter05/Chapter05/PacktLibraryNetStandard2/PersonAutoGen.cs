﻿namespace Packt.Shared;
public class PersonAutoGen
{
}

public partial class Person
{
	// a readonly property defined using C# 1 - 5 syntax
	public string Origin
	{
		get
		{
			return string.Format("{0} was born on {1}",
			arg0: Name, arg1: HomePlanet);
		}
	}
	// two readonly properties defined using C# 6+ lambda expression body syntax
	public string Greeting => $"{Name} says 'Hello!'";
	public int Age => DateTime.Today.Year - DateOfBirth.Year;

	// a read-write property defined using C# 3.0 syntax
	public string? FavoriteIceCream { get; set; } // auto-syntax

	// a private field to store the property value
	private string? favoritePrimaryColor;
	// a public property to read and write to the field
	public string? FavoritePrimaryColor
	{
		get
		{
			return favoritePrimaryColor;
		}
		set
		{
			switch (value?.ToLower())
			{
				case "red":
				case "green":
				case "blue":
					favoritePrimaryColor = value;
					break;
				default:
					throw new ArgumentException(
					$"{value} is not a primary color. " +
					"Choose from: red, green, blue.");
			}
		}
	}

	private bool married = false;
	public bool Married => married;
	private Person? spouse = null;
	public Person? Spouse => spouse;

	// static method to marry
	public static void Marry(Person p1, Person p2)
	{
		p1.Marry(p2);
	}

	// instance method to marry
	public void Marry(Person partner)
	{
		if (married) return;
		spouse = partner;
		married = true;
		partner.Marry(this); // this is the current object
	}

	// static method to "multiply"
	public static Person Procreate(Person p1, Person p2)
	{
		if (p1.Spouse != p2)
		{
			throw new ArgumentException("You must be married to procreate.");
		}
		Person baby = new()
		{
			Name = $"Baby of {p1.Name} and {p2.Name}",
			DateOfBirth = DateTime.Now
		};
		p1.Children.Add(baby);
		p2.Children.Add(baby);
		return baby;
	}
	// instance method to "multiply"
	public Person ProcreateWith(Person partner)
	{
		return Procreate(this, partner);
	}

	// method with a local function
	public static int Factorial(int number)
	{
		if (number < 0)
		{
			throw new ArgumentException(
			$"{nameof(number)} cannot be less than zero.");
		}
		return localFactorial(number);
		int localFactorial(int localNumber) // local function
		{
			if (localNumber == 0) return 1;
			return localNumber * localFactorial(localNumber - 1);
		}
	}

}

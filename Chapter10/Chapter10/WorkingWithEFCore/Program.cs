using Microsoft.EntityFrameworkCore;
using Packt.Shared;

QueryingCategories();



static void FilteredIncludes()
{
	using(Northwind db = new())
	{

	}
}

static void QueryingCategories()
{
	using (Northwind db = new())
	{
		SectionTitle("Categories and how many products they have:");
		// a query to get all categories and their related products
		IQueryable<Category>? categories = db.Categories?
		.Include(c => c.Products);
		if ((categories is null) || (!categories.Any()))
		{
			Fail("No categories found.");
			return;
		}
		// execute query and enumerate results
		foreach (Category c in categories)
		{
			WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
	    }
	}
}


static void SectionTitle(string title)
{
	ConsoleColor previousColor = ForegroundColor;
	ForegroundColor = ConsoleColor.Yellow;
	WriteLine("*");
	WriteLine($"* {title}");
	WriteLine("*");
	ForegroundColor = previousColor;
}
static void Fail(string message)
{
	ConsoleColor previousColor = ForegroundColor;
	ForegroundColor = ConsoleColor.Red;
	WriteLine($"Fail > {message}");
	ForegroundColor = previousColor;
}
static void Info(string message)
{
	ConsoleColor previousColor = ForegroundColor;
	ForegroundColor = ConsoleColor.Cyan;
	WriteLine($"Info > {message}");
	ForegroundColor = previousColor;
}

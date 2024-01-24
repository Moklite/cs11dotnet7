using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using Microsoft.EntityFrameworkCore.ChangeTracking;

//QueryingCategories();
//FilteredIncludes();
//QueryingProducts();
//GetRandomProduct();
//ListProducts();
//var resultAdd = AddProduct(categoryId: 6,
// productName: "Bob's Burgers", price: 500M);
//if (resultAdd.affected == 1)
//{
//	WriteLine($"Add product successful with ID: {resultAdd.productId}.");
//}
//ListProducts(productIdsToHighlight: new int[] { resultAdd.productId });

//var resultUpdate = IncreaseProductPrice(
// productNameStartsWith: "Bob", amount: 20M);
//if (resultUpdate.affected == 1)
//{
//	WriteLine("Increase price success for ID: {resultUpdate.productId}.");
//}
//ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });

//WriteLine("About to delete all products whose name starts with Bob.");
//Write("Press Enter to continue or any other key to exit: ");
//if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
//{
//	int deleted = DeleteProducts(productNameStartsWith: "Bob");
//	WriteLine($"{deleted} product(s) were deleted.");
//}
//else
//{
//	WriteLine("Delete was canceled.");
//}

//var resultUpdateBetter = IncreaseProductPricesBetter(
// productNameStartsWith: "Bob", amount: 20M);
//if (resultUpdateBetter.affected > 0)
//{
//	WriteLine("Increase product price successful.");
//}
//ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);

WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
	int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");
	WriteLine($"{deleted} product(s) were deleted.");
}
else
{
	WriteLine("Delete was canceled.");
}

//queries

static int DeleteProductsBetter(string productNameStartsWith)
{
	using (Northwind db = new())
	{
		int affected = 0;
		IQueryable<Product>? products = db.Products?.Where(
		p => p.ProductName.StartsWith(productNameStartsWith));
		if ((products is null) || (!products.Any()))
		{
			WriteLine("No products found to delete.");
			return 0;
		}
		else
		{
			affected = products.ExecuteDelete();
		}
		return affected;
	}
}

static (int affected, int[]? productIds) IncreaseProductPricesBetter(
 string productNameStartsWith, decimal amount)
{
	using (Northwind db = new())
	{
		if (db.Products is null) return (0, null);
		// Get products whose name starts with the parameter value.
		IQueryable<Product>? products = db.Products.Where(
		p => p.ProductName.StartsWith(productNameStartsWith));
		int affected = products.ExecuteUpdate(s => s.SetProperty(
		p => p.Cost, // Property selector lambda expression.
		p => p.Cost + amount)); // Value to update to lambda expression.
		int[] productIds = products.Select(p => p.ProductId).ToArray();
		return (affected, productIds);
	}
}

static int DeleteProducts(string productNameStartsWith)
{
	using (Northwind db = new())
	{
		IQueryable<Product>? products = db.Products?.Where(
		p => p.ProductName.StartsWith(productNameStartsWith));
		if ((products is null) || (!products.Any()))
		{
			WriteLine("No products found to delete.");
			return 0;
		}
		else
		{
			if (db.Products is null) return 0;
				db.Products.RemoveRange(products);
		}
		int affected = db.SaveChanges();
		return affected;
	}
}

static (int affected, int productId) IncreaseProductPrice(
 string productNameStartsWith, decimal amount)
{
	using (Northwind db = new())
	{
		if (db.Products is null) return (0, 0);
		// Get the first product whose name starts with the parameter value.
		Product? updateProduct = db.Products.FirstOrDefault(
		p => p.ProductName.StartsWith(productNameStartsWith));
		if (updateProduct is null)
		{
			return(0, 0);
		}
		else
		{
			updateProduct.Cost += amount;
			int affected = db.SaveChanges();
			return (affected, updateProduct.ProductId);
		}
	}
}

static (int affected, int productId) AddProduct(
 int categoryId, string productName, decimal? price)
{
	using (Northwind db = new())
	{
		if (db.Products is null) return (0, 0);
		Product p = new()
		{
			CategoryId = categoryId,
			ProductName = productName,
			Cost = price,
			Stock = 72
		};
		// set product as added in change tracking
		EntityEntry<Product> entity = db.Products.Add(p);
		WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
		// save tracked change to database
		int affected = db.SaveChanges();
		WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
		return (affected, p.ProductId);
	}
}

static void ListProducts(int[]? productIdsToHighlight = null)
{
	using (Northwind db = new())
	{
		if ((db.Products is null) || (!db.Products.Any()))
		{
			Fail("There are no products.");
			return;
		}
		WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
		"Id", "Product Name", "Cost", "Stock", "Disc.");
		foreach (Product p in db.Products)
		{
			ConsoleColor previousColor = ForegroundColor;
			if ((productIdsToHighlight is not null) &&
			productIdsToHighlight.Contains(p.ProductId))
			{
				ForegroundColor = ConsoleColor.Green;
			}
			WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
			p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
			ForegroundColor = previousColor;
		}
	}
}


static void GetRandomProduct()
{
	using (Northwind db = new())
	{
		SectionTitle("Get a random product.");
		int? rowCount = db.Products?.Count();
		if (rowCount == null)
		{
			Fail("Products table is empty.");
			return;
		}
		Product? p = db.Products?.FirstOrDefault(
		p => p.ProductId == (int)(EF.Functions.Random() * rowCount));
		if (p == null)
		{
			Fail("Product not found.");
			return;
		}
		WriteLine($"Random product: {p.ProductId} {p.ProductName}");
	}
}

static void QueryingWithLike()
{
	using(Northwind db = new())
	{
		SectionTitle("Pattern matching with LIKE.");
		Write("Enter part of a product name: ");
		string? input = ReadLine();
		if (string.IsNullOrWhiteSpace(input))
		{
			Fail("You did not enter part of a product name.");
			return;
		}
		IQueryable<Product>? products = db.Products?
		.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
		if ((products is null) || (!products.Any()))
		{
			Fail("No products found.");
			return;
		}
		foreach (Product p in products)
		{
			WriteLine("{0} has {1} units in stock. Discontinued? {2}",
			p.ProductName, p.Stock, p.Discontinued);
		}
	}
}

static void QueryingProducts()
{
	using (Northwind db = new())
	{
		SectionTitle("Products that cost more than a price, highest at top.");

		string? input;
		decimal price;

		do
		{
			Write("Enter a product price: ");
			input = ReadLine();
		} while (!decimal.TryParse(input, out price));

		IQueryable<Product>? products = db.Products?.TagWith("filtering products and ordering by price").Where(p => p.Cost > price).OrderByDescending(p => p.Cost);

		if ((products is null) || (!products.Any()))
		{
			Fail("No products found.");
			return;
		}
		foreach (Product p in products)
		{
			WriteLine(
			"{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
			p.ProductId, p.ProductName, p.Cost, p.Stock);

			Info($"ToQueryString: {products.ToQueryString()}");
		}
	}
}

static void FilteredIncludes()
{
	using(Northwind db = new())
	{
		SectionTitle("Products with a minimum number of units in stock.");

		string? input;
		int stock;
		do
		{
			WriteLine("Enter minimum units in stock: ");
			input = ReadLine();
		} while (!int.TryParse(input, out stock));

		IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));
		if((categories is null) || (!categories.Any()))
		{
			Fail("No categories found");
			return;
		}
		foreach (Category c in categories)
		{
			WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
			 foreach (Product p in c.Products)
			 {
				WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
			 }
		}
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

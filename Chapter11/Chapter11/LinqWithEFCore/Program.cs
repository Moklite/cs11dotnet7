using Microsoft.EntityFrameworkCore;
using Packt.Shared;


FilterAndSort();




//functions
static void FilterAndSort()
{
    SectionTitle("Filter and sort");
    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;
        IQueryable<Product> filteredProducts =
       allProducts.Where(product => product.UnitPrice < 10M);

        var sortedAndFilteredProducts =
        filteredProducts.OrderByDescending(product => product.UnitPrice);
        WriteLine(sortedAndFilteredProducts.ToQueryString());
        WriteLine("Products that cost less than $10:");
        foreach (Product p in sortedAndFilteredProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
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
using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using Packt.Shared;
using System.Diagnostics;

namespace Northwind.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext db;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new
                (
                 VisitorCount: Random.Shared.Next(1, 100),
                 Categories: db.Categories.ToList(),
                 Products: db.Products.ToList()
                );

            return View(model);
        }

        public IActionResult ProductDetail(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("You must pass a product ID in the route, for example, /Home/ProductDetail/21");
            }
            Product? model = db.Products.SingleOrDefault(p => p.ProductId == id);
            if (model is null)
            {
                return NotFound($"ProductId {id} not found.");
            }
            return View(model); // pass model to view and then return result
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ModelBinding()
        {
            return View(); // the page with a form to submit
        }

        [HttpPost]
        public IActionResult ModelBinding(Thing thing)
        {
            HomeModelBindingViewModel model = new(
             Thing: thing, HasErrors: !ModelState.IsValid,
             ValidationErrors: ModelState.Values
             .SelectMany(state => state.Errors)
             .Select(error => error.ErrorMessage)
            );
            return View(model);
        }
    }
}
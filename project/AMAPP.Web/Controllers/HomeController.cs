using AMAPP.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AMAPP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99m, Quantity = 5 },
            new Product { Id = 2, Name = "Product B", Price = 20.49m, Quantity = 3 },
            new Product { Id = 3, Name = "Product C", Price = 15.75m, Quantity = 8 }
        };

            return View(products);
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
    }
}

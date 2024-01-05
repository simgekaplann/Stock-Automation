using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sql_deneme.Models;
using sql_deneme.ViewModels;
using System.Diagnostics;
using System.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace sql_deneme.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqldenemeContext _context;

        public HomeController(ILogger<HomeController> logger, SqldenemeContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {/*
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmamışsa, login sayfasına yönlendir
                return RedirectToAction("Login", "Account");
            }
            */
            var suppliers = _context.Suppliers.ToList();
           var customers = _context.Customers.ToList();
            var products = _context.Products.ToList();
            var stockmovements = _context.StockMovements.ToList();

            var viewModel = new HomeViewModel
            {
                Suppliers = suppliers,
                Customers = customers,
                Products = products,
                StockMovements = stockmovements
               
            };

            return View(viewModel);
        }

       // [Authorize]
        public IActionResult StockStatusReport()
        {
            return View();
        }
      
        public IActionResult Customers()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        public IActionResult Suppliers()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        public IActionResult Orders()
        {
            var orders = _context.Orders.ToList();
            var orderDetails = _context.OrderDetails.ToList();

            var viewModel = new OrdersViewModel
            {
                Orders = orders,
                OrderDetails = orderDetails
            };

            return View(viewModel);
        }

        public IActionResult StockMovements()
        {
            var stockmovements = _context.StockMovements.ToList();
            return View(stockmovements);

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


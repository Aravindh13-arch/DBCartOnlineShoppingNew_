using AspnetIdentityRoleBasedTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingProject.BAL;
using System.Diagnostics;

namespace AspnetIdentityRoleBasedTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductImplemenationBAL productimplemenationbal;
        public HomeController(ILogger<HomeController> logger, ProductImplemenationBAL productimplemenation)
        {
            _logger = logger;
            productimplemenationbal = productimplemenation;
        }

        public async Task<IActionResult> Index()
        {

            var productList = await productimplemenationbal.GetCategroyWiseProductList();
            return View(productList);
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

        public async Task<IActionResult> About()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }


    }
}
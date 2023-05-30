using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingProject.BAL;

namespace AspnetIdentityRoleBasedTutorial.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {

        private ProductImplemenationBAL productimplemenationbal;
        public ProductController(ProductImplemenationBAL productimplemenation)
        {
            this.productimplemenationbal = productimplemenation;
        }
        public async Task<IActionResult> ProductDetails()
        {
            
           return View(await productimplemenationbal.GetProductList());
        }
        public IActionResult GetAll()
        {
            return View();
        }

        public IActionResult fashion()
        {
            return View();
        }

        public IActionResult groceries()
        {
            return View();
        }
    }
}

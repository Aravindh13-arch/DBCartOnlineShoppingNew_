using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingProject.BAL;
using OnlineShoppingProject.DAL;
using OnlineShoppingProject.ViewModels.ProductModels;

namespace OnlineShoppingProject.Controllers
{
    public class CartController : Controller
    {
        private CommonImplementationDAL _commonImplementation;
        private CartImplememntationBAL _cartImplementation;
        public CartController(CartImplememntationBAL cartImplementation, CommonImplementationDAL commonImplementation)
        {
            this._cartImplementation = cartImplementation;
            this._commonImplementation = commonImplementation;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CartList()
        {

            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            var userId = _commonImplementation.GetTheUserIdDAL(UserName);
            var model = await _cartImplementation.GetProductCartBAL(userId);

            return View(model);
        }
        public async Task<IActionResult> InsertToCart(ProductVM product)
        {

            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            product.UserId = _commonImplementation.GetTheUserIdDAL(UserName);
            if (await _cartImplementation.InsertCartBAL(product))
            {
                return RedirectToPage("/Cart/CartList");
                // return Json(new { isValid = true, message = "Cart item added successfully." });
            }
            else
            {
                return Json(new { isValid = false, html = "<h1>failed to submit</h1>" });
            }

        }
    }
}

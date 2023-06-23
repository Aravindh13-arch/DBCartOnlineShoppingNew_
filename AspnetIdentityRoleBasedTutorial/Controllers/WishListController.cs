using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using onlineShopping.BAL;
using onlineShopping.DAL;
using OnlineShoppingProject.DAL;

namespace onlineShopping.Controllers
{
	public class WishListController : Controller
	{
		private WishListImplementation WishListimplemenation;
        private CommonImplementationDAL _commonImplementation;

        public WishListController(WishListImplementation WishListimplemenation,CommonImplementationDAL commonImplementationDAL)
		{
			this.WishListimplemenation = WishListimplemenation;
			_commonImplementation = commonImplementationDAL;
		}
		[HttpGet]
		public async Task<IActionResult> GetWishList()
		{
            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            var userId = _commonImplementation.GetTheUserIdDAL(UserName);
            var model = await WishListimplemenation.GetWishListAsync(userId);
			return View(model);
		}



		public async Task<IActionResult> AddWishList(int ProductId)
		{
            //var UserName = HttpContext.User.Identity.Name;
            //int userId = LoginImplementationDAL.GetTheUserIdDAL(UserName);
            // userId = CommonImplementation.GetUserId(this.HttpContext);
            if (await WishListimplemenation.InsertWishListAsync(ProductId))
            {
                return RedirectToAction("GetWishList", "WishList");
            }
            else
            {
                return Json(new { isValid = false, html = "<h1>failed to submit</h1>" });
            }

   //         var model = await WishListimplemenation.InsertWishListAsync(ProductId);
			//return View(model);
		}

        //public async Task<IActionResult> GetWishList()
        //{
        //    return View();
        //}
    }
}


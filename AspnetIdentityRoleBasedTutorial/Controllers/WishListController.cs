using Microsoft.AspNetCore.Mvc;
using onlineShopping.BAL;
using onlineShopping.DAL;

namespace onlineShopping.Controllers
{
	public class WishListController : Controller
	{
		private WishListImplementation WishListimplemenation;
		public WishListController(WishListImplementation WishListimplemenation)
		{
			this.WishListimplemenation = WishListimplemenation;
		}
//		[HttpGet]
//		public async Task<IActionResult> GetWishList()
//		{
//			var UserName = HttpContext.User.Identity.Name;
//			int userId = LoginImplementationDAL.GetTheUserIdDAL(UserName);
//			var model = await WishListimplemenation.GetWishListAsync(userId);
//			return View(model);
//		}


		
		public async Task<IActionResult> AddWishList(int ProductId)
		{
			//var UserName = HttpContext.User.Identity.Name;
			//int userId = LoginImplementationDAL.GetTheUserIdDAL(UserName);
           // userId = CommonImplementation.GetUserId(this.HttpContext);
            var model = await WishListimplemenation.InsertWishListAsync(ProductId);
			return View(model);
		}

        public async Task<IActionResult> GetWishList()
        {
            return View();
        }
    }
}


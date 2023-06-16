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
      //GetProductDetails
      public async Task<IActionResult> GetProductDetails(int id)
      {
         return View(await productimplemenationbal.GetProductDetailBAL(id));
      }

      public async Task<IActionResult> ProductDetails()
      {
         return View(await productimplemenationbal.GetCategroyWiseProductList());
      }

      //Product Category - Appliances
      public async Task<IActionResult> ProductCategory()
      {
         return View(await productimplemenationbal.GetProductCategoryList());
      }

      //Product Category - Mobiles
      public async Task<IActionResult> ProductCategoryMobile()
      {
         return View(await productimplemenationbal.GetProductCategoryMobileList());
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

      public IActionResult travel()
      {
         return View();
      }

      public async Task<IActionResult> GetListfashion(int id)
      {
         return View(await productimplemenationbal.GetFashionList(id));
      }
      //Grocery From Database

      public async Task<IActionResult> groceriesDb()
      {
         return View(await productimplemenationbal.GetGroceryListBAL());
      }

        public IActionResult Electronic()
        {
            return View();
        }
   }
}



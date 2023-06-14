using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.BAL;
using OnlineShoppingProject.DAL;
using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.Controllers
{
    public class AddressController : Controller
    {

        private OnlineShopDbContext _context;
        private AddressImplementation AddressImplemenation;

        public AddressController(AddressImplementation AddressImplemenation, OnlineShopDbContext context)
        {
            this.AddressImplemenation = AddressImplemenation;
            this._context = context;
        }

        public IActionResult GetAddressId(int id)
        {
         
            var userName =HttpContext.User.Identity.Name;
   
            if (userName == null)
            {



                return Redirect("/Identity/Account/Login");
            }
            var userId = _context.AspNetUsers.Single(r => r.Email == userName).Id;
            var buy = AddressImplemenation.GetIDAddressBAL(userId, id);
            return View(buy);
        }


        public IActionResult OrderSummary()
        {
            return View();
        }

        public  IActionResult GetSelectSummary(int Id)
        {
             
            var select=AddressImplemenation.GetSelectSummaryBAL(Id);
            return View(select);


        }

       

    }
}

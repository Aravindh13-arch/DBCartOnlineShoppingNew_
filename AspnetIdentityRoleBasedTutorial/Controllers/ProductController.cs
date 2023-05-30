﻿using Microsoft.AspNetCore.Authorization;
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
        
        //Product Category
        public async Task<IActionResult> ProductCategory()
        {
            return View(await productimplemenationbal.GetProductCategoryList());
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
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingProject.BAL;
using OnlineShoppingProject.DAL;
using OnlineShoppingProject.ViewModels.CategoryWiseList;
using OnlineShoppingProject.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using OnlineShoppingProject.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
            ViewData["CartItemCount"] = model;
            ViewBag.CartItems = model;
            return View(model);
        }

        public async Task<IActionResult> RemoveCartList(int id)
        {
            //var product = await _cartImplementation.GetCartById(id);
            return View(id);
        }



        public async Task<IActionResult> ConfirmDelete(int ProductId)
        {
            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return Redirect("/Identity/Account/Login");
                //return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            string UserId = _commonImplementation.GetTheUserIdDAL(UserName);
            if (await _cartImplementation.RemoveCartbyId(ProductId))
            {
                return RedirectToAction("CartList", "Cart");
            }
            else
            {
                return Json(new { isValid = false, html = "<h1>failed to submit</h1>" });
            }
        }

        public async Task<IActionResult> cart()
        {
            return View();
        }

        public async Task<IActionResult> CheckOut()
        {

            var userName = HttpContext.User.Identity.Name;
            if (userName == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var userId = _commonImplementation.GetTheUserIdDAL(userName);
            var totalProduct = await _cartImplementation.GetCheckOutBAL(userId);
            return View(totalProduct);
        }
        public IActionResult GetCartCount()
        {
            var cartCount = _cartImplementation.GetCartCount(); 

            return Json(cartCount.count); 
        }

        public async Task<IActionResult> InsertToCart(ProductVM product)
        {
            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
                //return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            product.UserId = _commonImplementation.GetTheUserIdDAL(UserName);
            if (await _cartImplementation.InsertCartBAL(product))
            {
                return RedirectToAction("CartList", "Cart");

                // return Json(new { isValid = true, message = "Cart item added successfully." });
            }
            else
            {
                return Json(new { isValid = false, html = "<h1>failed to submit</h1>" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCart(int Id,int quantity,decimal payableAmount)
        {
            string UserName = HttpContext.User.Identity.Name;
            if (UserName.IsNullOrEmpty())
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
                var UserId = _commonImplementation.GetTheUserIdDAL(UserName);
            if (await _cartImplementation.UpdateCartBAL(Id, quantity, payableAmount, UserId))
            {
                return RedirectToAction("CartList", "Cart");
            }
            else
            {
                return Json(new { isValid = false, html = "<h1>failed to submit</h1>" });
            }
        }


    }
}

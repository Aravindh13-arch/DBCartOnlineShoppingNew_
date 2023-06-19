﻿using AspnetIdentityRoleBasedTutorial.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.Constants;
using OnlineShoppingProject.ViewModels.ProductModels;
using OnlineShoppingProject.ViewModels.CategoryWiseList;

namespace OnlineShoppingProject.DAL
{
    public class CartImplememntationDAL
    {
        private OnlineShopDbContext _context;

        public CartImplememntationDAL(OnlineShopDbContext Context)
        {
            _context = Context;
        }

        public async Task<bool> AddToCart(ProductVM product)
        {

            try
            {
                var res = _context.TblCarts.FirstOrDefault(r => r.ProductId == product.Id);
                if (res == null)
                {
                    _context.TblCarts.Add(new TblCart
                    {
                        Product = _context.TblProducts.Single(r => r.ProductId == product.Id),
                        Quantity = product.quantity,
                        SizeId=product.size,
                        Rate = _context.TblProducts.Single(r => r.ProductId == product.Id).Rate,
                        Totalamount = _context.TblProducts.Single(r => r.ProductId == product.Id).Rate*product.quantity,
                        Description = _context.TblProducts.Single(r => r.ProductId == product.Id).Description,
                        CreatedAt = DateTime.UtcNow,
                        Status = (int)MyConstants.Status.Active,
                        CreatedBy = _context.AspNetUsers.Single(r=>r.Id == product.UserId).Id
                    });
                    
                }
                else
                {
                    res.Quantity += product.quantity;
                    res.Totalamount += _context.TblProducts.Single(r => r.ProductId == product.Id).Rate * product.quantity;
                }
                var result = await _context.SaveChangesAsync();
                if (result > 0) { return true; }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public async Task<List<TblCart>> GetAllProductCart(string UserId)
        {
            var result = _context.TblCarts.Include(r => r.Product).Select(r => r).Where(r => r.CreatedBy == UserId).ToList();
            return result;
        }

        public cartcount GetCartCount()
        {
            if (_context != null)
            {
                var result = _context.TblCarts.Count();
                cartcount cartcount = new cartcount();
                cartcount.count = result;
                return cartcount;
            }
            else
            {
                throw new Exception();
            }
        }
        public async Task<TblCart> GetCartById(int id)
        {
                return await _context.TblCarts.FindAsync(id);
           
        }

        public async Task<bool> RemoveCartbyId(ProductVM productVM)
        {

            try
            {
                var productDB = _context.TblCarts.Where(x => x.CartId == productVM.Id).FirstOrDefault();
                {
                    productDB.Status = (int)MyConstants.Status.Deleted;
                    productDB.UpdatedAt = DateTime.UtcNow;
                    productDB.UpdatedBy = _context.AspNetUsers.Single(r => r.Id == productVM.UserId).Id;
                }
                var result = await _context.SaveChangesAsync();
                if (result > 0) { return true; }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

       
    }
}

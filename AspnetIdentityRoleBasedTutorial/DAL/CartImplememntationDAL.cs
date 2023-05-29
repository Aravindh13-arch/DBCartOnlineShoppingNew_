using AspnetIdentityRoleBasedTutorial.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.Constants;
using OnlineShoppingProject.ViewModels.ProductModels;

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
                        Rate = _context.TblProducts.Single(r => r.ProductId == product.Id).Rate * product.quantity,
                        Description = _context.TblProducts.Single(r => r.ProductId == product.Id).Description,
                        CreatedAt = DateTime.UtcNow,
                        Status = (int)MyConstants.Status.Active,
                        CreatedBy = _context.AspNetUsers.Single(r=>r.Id == product.UserId).Id
                    });
                }
                else
                {
                    res.Quantity += product.quantity;
                    res.Rate += _context.TblProducts.Single(r => r.ProductId == product.Id).Rate * product.quantity;
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
            return await _context.TblCarts.Include(r => r.Product).Select(r => r).Where(r => r.CreatedBy == UserId).ToListAsync();            
        }
    }
}

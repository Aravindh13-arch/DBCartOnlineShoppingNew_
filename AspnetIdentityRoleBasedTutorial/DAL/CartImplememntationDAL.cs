using AspnetIdentityRoleBasedTutorial.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.Constants;
using OnlineShoppingProject.ViewModels.CategoryWiseList;
using OnlineShoppingProject.ViewModels;
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
                    int? newSizeId = null;
                    if (product.size != null)
                    {
                        newSizeId = _context.TblSizes.SingleOrDefault(r => r.SizeId == product.size)?.SizeId;
                    }

                    _context.TblCarts.Add(new TblCart
                    {
                        Product = _context.TblProducts.Single(r => r.ProductId == product.Id),
                        Quantity = product.quantity,

                        SizeId = newSizeId,

                        Rate = _context.TblProducts.Single(r => r.ProductId == product.Id).Rate,
                        Totalamount = _context.TblProducts.Single(r => r.ProductId == product.Id).Rate * product.quantity,
                        Description = _context.TblProducts.Single(r => r.ProductId == product.Id).Description,
                        CreatedAt = DateTime.UtcNow,
                        Status = (int)MyConstants.Status.Active,
                        CreatedBy = _context.AspNetUsers.Single(r => r.Id == product.UserId).Id
                    });

                }
                else
                {
                    res.Quantity += product.quantity;
                    res.Totalamount += _context.TblProducts.Single(r => r.ProductId == product.Id).Rate * product.quantity;
                }
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<AddProductCartVM> GetAllProductCart(string UserId)
        {
            var result = _context.TblCarts.Include(r => r.Product).Select(r => r).Where(r => r.CreatedBy == UserId).ToList();
            AddProductCartVM addProductCartVM = new AddProductCartVM();
            addProductCartVM.TblCarts = result;

            var ShipList = _context.TblShips.ToList();
            addProductCartVM.TblShipsList = ShipList;
            return addProductCartVM;
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

        public async Task<bool> RemoveCartbyId(int ProductId)
        {

            try
            {
                var product = _context.TblCarts.Single(r => r.ProductId == ProductId);
                _context.TblCarts.Remove(product);
                var result = await _context.SaveChangesAsync();
                if (result > 0) { return true; }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        //public async Task<bool> UpdateCartby(List<AddProductCartVM> productVM)
        //{

        //    try
        //    {
        //        foreach (var item in productVM)
        //        {
        //            TblCart tblCart = new TblCart();
        //            var productDB = _context.TblCarts.Where(x => x.CartId == item.AddCartProductId).FirstOrDefault();
        //            tblCart.Quantity = productDB.Quantity;
        //            tblCart.Totalamount = productDB.Totalamount;
        //        }
        //           var result = await _context.SaveChangesAsync();
        //           if (result > 0) { return true; }
        //           return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    };
        //}

        public async Task<bool> UpdateCartby(int Id, int quantity, decimal payableAmount, string UserId)
        {
            try
            {
                var result = _context.TblCarts.Single(r => r.ProductId == Id);
                {
                    result.Quantity = quantity;
                    result.Totalamount = payableAmount;
                    result.UpdatedAt = DateTime.UtcNow;
                    result.UpdatedBy = _context.AspNetUsers.Single(r => r.Id == UserId).Id;
                }
                var affectedRows = await _context.SaveChangesAsync();
                if (affectedRows > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<PlaceOrderVM> GetCheckOutDAL(string userId)
        {
            List<PlaceOrderVM> placeOrderVMs = new List<PlaceOrderVM>();
            PlaceOrderVM placeOrder = new PlaceOrderVM();

            var productList = await _context.TblCarts.Include(r => r.Product).Select(r => r).Where(r => r.CreatedBy == userId).ToListAsync();
           
            placeOrder.TblCarts = productList;
       
            var paymentTypes = await _context.TblPaymentTypes.ToListAsync();
            placeOrder.TblPaymentTypesVM = paymentTypes;
      
            return placeOrder;
        }

        public async Task<bool> ProcessToCheckOutDAL(CheckOutVM checkOutVM,string UserId)
        {
          
           
            var cartIds = await _context.TblCarts.Where(c => c.CreatedBy == UserId).Select(c => c.CartId).ToListAsync();

            if (cartIds != null && cartIds.Count > 0)
            {
                foreach (var cartId in cartIds)
                {
                    _context.TblOrderItems.Add(new TblOrderItem
                    {
                        CartId = cartId,
                        Status = (int)Constants.MyConstants.Status.Active,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = _context.AspNetUsers.Single(r => r.Id == UserId).Id,
                    });
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

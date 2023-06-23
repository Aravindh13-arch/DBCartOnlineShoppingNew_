using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.DAL;
using OnlineShoppingProject.ViewModels.CategoryWiseList;
using OnlineShoppingProject.ViewModels;
using OnlineShoppingProject.ViewModels.ProductModels;


namespace OnlineShoppingProject.BAL
{
    public class CartImplememntationBAL
    {
        private CartImplememntationDAL _cartImplementation;
        public CartImplememntationBAL(CartImplememntationDAL cartImplementation)
        {
            this._cartImplementation = cartImplementation;
        }
        public async Task<AddProductCartVM> GetProductCartBAL(string Id)
        {
            return new AddProductCartVM
            {
                TblCarts = await _cartImplementation.GetAllProductCart(Id),
            };

        }
        public async Task<bool> InsertCartBAL(ProductVM product)
        {
            return await _cartImplementation.AddToCart(product);

        }

        public async Task<ProductVM> GetCartById(int id)
        {
            var product = await _cartImplementation.GetCartById(id);
            ProductVM productVM = new ProductVM();
            productVM.Id = product.CartId;
            productVM.ProductId = product.ProductId;
            productVM.Description = product.Description;
            productVM.quantity = product.Quantity;
            productVM.Rate = product.Rate;    

            return productVM;
        }

        public async Task<bool> RemoveCartbyId(int ProductId)
        {
            return await _cartImplementation.RemoveCartbyId(ProductId);
        }

        public cartcount GetCartCount()
        {
            var result = _cartImplementation.GetCartCount();
            return result;
        }

        public async Task<bool> UpdateCartBAL(int Id, int quantity, decimal payableAmount,string UserId)
        {
            return await _cartImplementation.UpdateCartby(Id, quantity, payableAmount, UserId);
        }


        public async Task<PlaceOrderVM> GetCheckOutBAL(string userId)
        {
            try
            {
                return await _cartImplementation.GetCheckOutDAL(userId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ProcessToCheckOutBAL(CheckOutVM checkOutVM,string UserId)
        {
            try
            {
                return await _cartImplementation.ProcessToCheckOutDAL(checkOutVM, UserId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}

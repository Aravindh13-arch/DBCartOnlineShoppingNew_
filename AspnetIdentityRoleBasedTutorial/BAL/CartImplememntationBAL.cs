using OnlineShoppingProject.DAL;
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
                TblCarts = await _cartImplementation.GetAllProductCart(Id)
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

        public async Task<bool> RemoveCartbyId(ProductVM client)
        {
            return await _cartImplementation.RemoveCartbyId(client);
        }
    }
}

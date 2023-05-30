using OnlineShoppingProject.DAL;
using OnlineShoppingProject.ViewModels;

namespace OnlineShoppingProject.BAL
{
    public class ProductImplemenationBAL
    {
        private ProductImplemenationDAL productimplemenationDAL;
        public ProductImplemenationBAL(ProductImplemenationDAL productimplemenationDAL)
        {
            this.productimplemenationDAL = productimplemenationDAL;
        }
        public async Task<ProductVM> GetProductList()
        {
            return new ProductVM
            {
                TblProducts = await productimplemenationDAL.GetListOfProducts()
            };

        }

        // Product Category BAL 
        public async Task<ProductVM> GetProductCategoryList()
        {
            return new ProductVM
            {
                TblProducts = await productimplemenationDAL.GetListOfProductCategory()
            };

        }
    }
}

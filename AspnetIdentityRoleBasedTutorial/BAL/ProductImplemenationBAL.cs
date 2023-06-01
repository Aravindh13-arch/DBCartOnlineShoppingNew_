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


        public async Task<List<ProductVM>> GetFashionList(int id)
        {
            return await productimplemenationDAL.GetListfashion(id);
        }

        // Product Category BAL - Appliances
        public async Task<ProductVM> GetProductCategoryList()
        {
            return new ProductVM
            {
                TblProducts = await productimplemenationDAL.GetListOfProductCategory()
            };

        }

        // Product Category BAL - Mobiles
        public async Task<ProductVM> GetProductCategoryMobileList()
        {
            return new ProductVM
            {
                TblProducts = await productimplemenationDAL.GetListOfProductCategoryMobile()
            };

        }

        // Product Category BAL - Groceries
        public async Task<ProductVM> GetGroceryListBAL()
        {
            return new ProductVM
            {
                TblProducts = await productimplemenationDAL.GetListOfGroceryDAL()
            };

        }



    }
}

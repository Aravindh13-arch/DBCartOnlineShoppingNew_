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
    }
}

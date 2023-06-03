using OnlineShoppingProject.DAL;
using OnlineShoppingProject.ViewModels;
using OnlineShoppingProject.ViewModels.CategoryWiseList;

namespace OnlineShoppingProject.BAL
{
   public class ProductImplemenationBAL
   {
      private ProductImplemenationDAL productimplemenationDAL;
      public ProductImplemenationBAL(ProductImplemenationDAL productimplemenationDAL)
      {
         this.productimplemenationDAL = productimplemenationDAL;
      }

      public async Task<ProductVM> GetProductDetailBAL(int id)
      {
         return new ProductVM
         {
            TblProducts = await productimplemenationDAL.GetProductDetailDAL(id)
         };

      }

      public async Task<ProductVM> GetProductList()
      {
         return new ProductVM
         {
            TblProducts = await productimplemenationDAL.GetListOfProducts()
         };

      }

      public async Task<ProductCategroyList> GetCategroyWiseProductList()
      {
         return new ProductCategroyList
         {

            ElectronicsCategroy = await productimplemenationDAL.GetListOfElectronicsProducts(),
            FashionCategroy = await productimplemenationDAL.GetListOfFashionProducts(),
            Home_KitchenCategroy = await productimplemenationDAL.GetListOfHome_KitchenProducts(),
            BooksCategroy = await productimplemenationDAL.GetListOfBooksProducts(),
            SportsCategroy = await productimplemenationDAL.GetListOfSportsProducts(),
            Beauty_Personal_CarCategroy = await productimplemenationDAL.GetListOfBeauty_Personal_CareProducts()
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
      public async Task<ProductCategroyList> GetGroceryListBAL()
      {
         return new ProductCategroyList
         {
            MobliesCategroy = await productimplemenationDAL.GetListOfMobileProducts()
         };

      }



   }
}

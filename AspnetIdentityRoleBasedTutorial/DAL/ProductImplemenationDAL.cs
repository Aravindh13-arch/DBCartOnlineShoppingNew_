using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.DAL
{
    public class ProductImplemenationDAL
    {
        private OnlineShopDbContext _context;

        public ProductImplemenationDAL(OnlineShopDbContext Context)
        {
            _context = Context;
        }

        public async Task<List<TblProduct>> GetListOfProducts()
        {
            return await _context.TblProducts.Select(r => r).ToListAsync();
        }

        // Product Category DAL Appliances
        public async Task<List<TblProduct>> GetListOfProductCategory()
        {
            try
            {
                var result = await _context.TblCategories
                    .Join(_context.TblProducts, category => category.CategoryId, product => product.CategoryId,
                        (category, product) => new TblProduct
                        {
                            CategoryId = category.CategoryId,
                            ProductName = product.ProductName,
                            Image = product.Image,
                            Rate = product.Rate

                        })
                    .Where(product => product.CategoryId == 3)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                return new List<TblProduct>();
            }
        }


        // Product Category DAL Mobiles
        public async Task<List<TblProduct>> GetListOfProductCategoryMobile()
        {
            try
            {
                var result = await _context.TblSubCategories
                    .Join(_context.TblProducts, category => category.SubCategoryId, product => product.SubCategoryId,
                        (category, product) => new TblProduct
                        {
                            SubCategoryId = category.SubCategoryId,
                            ProductName = product.ProductName,
                            Image = product.Image,
                            Rate = product.Rate

                        })
                    .Where(product => product.SubCategoryId == 5)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                return new List<TblProduct>();
            }
        }     

    }
}

using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.ViewModels;
using System.Drawing;
using System.Security.Cryptography;

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

  public async Task<List<ProductVM>> GetListfashion(int id)
  {
   List<ProductVM> productList = new List<ProductVM>();

   var result = _context.TblProducts
     .Join(_context.TblCategories,
      r1 => r1.CategoryId,
      r2 => r2.CategoryId, (r1, r2) => new { r1, r2 })
     .Join(_context.TblSubCategories,
     r3 => r3.r1.SubCategoryId,
     r4 => r4.SubCategoryId, (r3, r4) => new { r3, r4 })
     .Join(_context.TblBrands,
     r5 => r5.r3.r1.BrandId,
     r6 => r6.BrandId, (r5, r6) => new { r5, r6 })
     .Select(r => new
     {
      ProductId = r.r5.r3.r1.ProductId,
      ProductName = r.r5.r3.r1.ProductName,
      ProductCode = r.r5.r3.r1.ProductCode,
      Rate = r.r5.r3.r1.Rate,
      Image = r.r5.r3.r1.Image,
      CategoryId = r.r5.r3.r1.CategoryId,
      SubCategoryId = r.r5.r3.r1.SubCategoryId,
      BrandId = r.r5.r3.r1.BrandId
     }).ToList();
   result = result.Where(r => r.CategoryId == id).ToList();
   foreach (var item in result)
   {
    ProductVM product = new ProductVM();
    product.Id = item.ProductId;
    product.CategoryId = item.CategoryId;
    product.SubCategoryId = item.SubCategoryId;
    product.BrandId = item.BrandId;
    product.ProductName = item.ProductName;
    product.Image = item.Image;
    product.Rate = item.Rate;
    productList.Add(product);
   }
   return productList;
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


  // Product Category DAL Groceries
  public async Task<List<TblProduct>> GetListOfGroceryDAL()
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
        .Where(product => product.CategoryId == 7)
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

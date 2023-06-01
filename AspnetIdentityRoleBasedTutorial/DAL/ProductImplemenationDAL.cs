using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.ViewModels;
using OnlineShoppingProject.ViewModels.CategoryWiseList;
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

        public async Task<List<Moblies>> GetListOfMobileProducts()
        {
            List<Moblies> MobileList = new List<Moblies>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {

                foreach (var list in product)
                {
                    if (list.CategoryId == 7)
                    {
                        Moblies moblies = new Moblies();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }
        public async Task<List<Electronics>> GetListOfElectronicsProducts()
        {
            List<Electronics> MobileList = new List<Electronics>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {

                foreach (var list in product)
                {
                    if (list.CategoryId == 1)
                    {
                        Electronics moblies = new Electronics();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }
        public async Task<List<Fashion>> GetListOfFashionProducts()
        {
            List<Fashion> MobileList = new List<Fashion>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {

                foreach (var list in product)
                {
                    if (list.CategoryId == 2)
                    {
                        Fashion moblies = new Fashion();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }
        public async Task<List<Home_Kitchen>> GetListOfHome_KitchenProducts()
        {
            List<Home_Kitchen> MobileList = new List<Home_Kitchen>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {
                foreach (var list in product)
                {
                    if (list.CategoryId == 3)
                    {
                        Home_Kitchen moblies = new Home_Kitchen();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }
        public async Task<List<Books>> GetListOfBooksProducts()
        {
            List<Books> MobileList = new List<Books>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {
                foreach (var list in product)
                {
                    if (list.CategoryId == 4)
                    {
                        Books moblies = new Books();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }
        public async Task<List<Sports>> GetListOfSportsProducts()
        {
            List<Sports> MobileList = new List<Sports>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {
                foreach (var list in product)
                {
                    if (list.CategoryId == 5)
                    {
                        Sports moblies = new Sports();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }

        public async Task<List<Beauty_Personal_Care>> GetListOfBeauty_Personal_CareProducts()
        {
            List<Beauty_Personal_Care> MobileList = new List<Beauty_Personal_Care>();
            var product = await _context.TblProducts.Select(r => r).ToListAsync();
            if (product != null)
            {
                foreach (var list in product)
                {
                    if (list.CategoryId == 6)
                    {
                        Beauty_Personal_Care moblies = new Beauty_Personal_Care();
                        moblies.BrandId = list.BrandId;
                        moblies.SubCategoryId = list.SubCategoryId;
                        moblies.UnitId = list.UnitId;
                        moblies.Status = list.Status;
                        moblies.Rate = list.Rate;
                        moblies.CreatedBy = list.CreatedBy;
                        moblies.UpdatedBy = list.UpdatedBy;
                        moblies.UpdatedAt = list.UpdatedAt;
                        moblies.CreatedAt = list.CreatedAt;
                        moblies.CategoryId = list.CategoryId;
                        moblies.Description = list.Description;
                        moblies.Image = list.Image;
                        moblies.ProductCode = list.ProductCode;
                        moblies.ProductId = list.ProductId;
                        moblies.ProductName = list.ProductName;
                        MobileList.Add(moblies);
                    }
                }

            }
            return MobileList;
        }

 }
}

using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Models;

namespace onlineShopping.DAL
{
	public class WishlistImplementationDAL
	{
		private readonly OnlineShopDbContext _context;
		public WishlistImplementationDAL(OnlineShopDbContext context)
		{
			_context = context;
		}
		public async Task<List<TblWishList>> GetListOfWishListDAL(string id)
		{
			return await _context.TblWishLists.Select(r => r).Where(r => r.CreatedBy == id).ToListAsync();
		}


		public async Task<bool> InsertValueOfWishList(int ProductId)
		{
			try
			{
                var res = _context.TblWishLists.FirstOrDefault(r => r.ProductId == ProductId);
				if (res == null)
				{
					_context.TblWishLists.Add(new TblWishList
                    {
						Product = _context.TblProducts.Single(r => r.ProductId == ProductId),
						CreatedAt = DateTime.Now,
						CreatedBy = _context.AspNetUsers.Select(r=>r.Id).First(),
						Status = 1
					});
				}
                else
                {
					var product = _context.TblWishLists.Single(r=>r.ProductId == res.ProductId);
					_context.TblWishLists.Remove(_context.TblWishLists.Find(product.ProductId));

                }
                var result = await _context.SaveChangesAsync();
				if (result > 0) { return true; }
				return false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

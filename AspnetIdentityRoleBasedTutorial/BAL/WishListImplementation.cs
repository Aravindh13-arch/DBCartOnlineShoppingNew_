using onlineShopping.DAL;
using OnlineShoppingProject.ViewModels;

namespace onlineShopping.BAL
{
	public class WishListImplementation
	{
		private readonly WishlistImplementationDAL wishlistImplementationDAL;
		public WishListImplementation(WishlistImplementationDAL wishlistImplementationDAL)
		{
			this.wishlistImplementationDAL = wishlistImplementationDAL;
		}
		public async Task<WishListVM>GetWishListAsync(string id)
		{
			return new WishListVM
			{
				tblWishLists = await wishlistImplementationDAL.GetListOfWishListDAL(id)
			};
		}
		public async Task<bool> InsertWishListAsync(int ProductId)
		{
			return await wishlistImplementationDAL.InsertValueOfWishList(ProductId);
		}
	}
}


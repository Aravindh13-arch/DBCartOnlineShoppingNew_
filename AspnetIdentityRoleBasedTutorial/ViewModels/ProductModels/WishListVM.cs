using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels.ProductModels
{
    public class WishListVM
    {
        public int WishListId { get; set; }

        public int? ProductId { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public List<TblWishList> tblWishLists { get; set; } = new List<TblWishList>();


    }
}

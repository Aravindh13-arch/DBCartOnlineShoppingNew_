using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels.ProductModels
{
    public class AddProductCartVM
    {
        public int AddCartProductId { get; set; }

        public int? ProductMasterId { get; set; }

        public int Quantity { get; set; }
        public int Count { get; set; }
        public decimal Rate { get; set; }

        public int Status { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedById { get; set; }

        public string? ModifiedById { get; set; }

        public List<TblCart>? TblCarts { get; set; } = new List<TblCart>();

        public List<TblShip>? TblShipsList { get; set; } = new List<TblShip>();

    }
}

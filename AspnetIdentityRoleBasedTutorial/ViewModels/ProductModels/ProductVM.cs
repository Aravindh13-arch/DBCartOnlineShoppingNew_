using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels.ProductModels
{
    public class ProductVM
    {
        public string UserId { get; set; }
        public int? ProductId { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public int size { get; set; }
        public int quantity { get; set; }

        public decimal Rate { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public List<TblProduct>? TblProducts { get; set; } = new List<TblProduct>();
    }
}

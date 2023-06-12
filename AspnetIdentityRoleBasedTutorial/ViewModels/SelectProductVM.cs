using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels
{
    public class SelectProductVM
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }
        public string ProductName { get; set; }

        public int quantity { get; set; }

        public decimal Rate { get; set; }
        public string? Image { get; set; }

        public TblProduct? TblProducts { get; set; } = new TblProduct();
    }
}

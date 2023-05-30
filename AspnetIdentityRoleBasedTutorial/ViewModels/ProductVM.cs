using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels
{
    public class ProductVM 
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        //public decimal Quantity { get; set; }
        public int quantity { get; set; }

        public decimal Rate { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public List<TblProduct>? TblProducts { get; set; } = new List<TblProduct>();
    }
}

using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels
{
    public class SelectProductVM
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductId { get; set; }

        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int quantity { get; set; }

        public decimal Rate { get; set; }
        public string? Image { get; set; }



        public List<TblSize>? TblSizes { get; set; } = new List<TblSize>();
        public TblProduct? TblProducts { get; set; } = new TblProduct();
        public List<TblImageVM>? TblImages { get; set; } = new List<TblImageVM>();

    }
    public class TblImageVM
    {
        public int Id { get; set; }
        public string? ThumbImage { get; set; }
        public string? Image { get; set; }
    }
}

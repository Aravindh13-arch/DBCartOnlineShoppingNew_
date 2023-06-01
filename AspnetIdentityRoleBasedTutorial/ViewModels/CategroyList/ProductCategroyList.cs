using static System.Reflection.Metadata.BlobBuilder;

namespace OnlineShoppingProject.ViewModels.CategoryWiseList
{
    public class ProductCategroyList
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        //public decimal Quantity { get; set; }
        public int quantity { get; set; }

        public decimal Rate { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public List<Moblies>? MobliesCategroy { get; set; } = new List<Moblies>();
        public List<Electronics>? ElectronicsCategroy { get; set; } = new List<Electronics>();
        public List<Fashion>? FashionCategroy { get; set; } = new List<Fashion>();
        public List<Home_Kitchen>? Home_KitchenCategroy { get; set; } = new List<Home_Kitchen>();
        public List<Books>? BooksCategroy { get; set; } = new List<Books>();
        public List<Sports>? SportsCategroy { get; set; } = new List<Sports>();
        public List<Beauty_Personal_Care>? Beauty_Personal_CarCategroy { get; set; } = new List<Beauty_Personal_Care>();
    }

    public class Moblies
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Electronics
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Fashion
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Home_Kitchen
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Books
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Sports
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
    public class Beauty_Personal_Care
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductCode { get; set; }

        public int UnitId { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        public int BrandId { get; set; }

        public decimal Rate { get; set; }

        public string Image { get; set; } = null!;

        public string? Description { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }
    }
}


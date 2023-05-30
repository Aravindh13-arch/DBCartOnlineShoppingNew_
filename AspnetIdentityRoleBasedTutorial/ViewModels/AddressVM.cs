using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels
{
    public class AddressVM
    {
        public int AddressId { get; set; }

        public int ProductId { get; set; }

        public string? Name { get; set; }
        public string? DeliverAddress { get; set; }
        public string? City { get; set; } 

        public string? State { get; set; } 

        public string? PinCode { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }


        public List<TblAddress>? TblProducts { get; set; } = new List<TblAddress>();
        public List<NameVM>? TblName { get; set; } = new List<NameVM>();
    }
    public class NameVM
    {
        public int AddressId { get; set; }
        public string? DeliverAddress { get; set; }
        public string? City { get; set; }

        public string? State { get; set; }

        public string? PinCode { get; set; }


    }

}

namespace OnlineShoppingProject.ViewModels
{
    public class CheckOutVM
    {

        public int ShipId { get; set; }
        public int paymentTypeId { get; set; }
        public int CartId { get; set; }
        public string UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string country { get; set; }
        public string streetAddress { get; set; }
        public string townCity { get; set; }
        public string stateCounty { get; set; }
        public string pinCode { get; set; }
        public string phone { get; set; }

        public short Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public string? UpdatedBy { get; set; }




    }
}

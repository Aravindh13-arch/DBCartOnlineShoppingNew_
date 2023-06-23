using OnlineShoppingProject.Models;

namespace OnlineShoppingProject.ViewModels
{
    public class PlaceOrderVM
    {
        public string ProductName { get; set; }
        public decimal? ProductTotalAmount { get; set; }
        public string UserId { get; set; }

        public List<TblCart>? TblCarts { get; set; } = new List<TblCart>();
        public List<TblPaymentType>? TblPaymentTypesVM { get; set; } = new List<TblPaymentType>();
    }
    public class PaymentTypesVM
    {
        public int PaymentTypesId { get; set; }
        public string PaymentTypes { get; set;}
    }
}

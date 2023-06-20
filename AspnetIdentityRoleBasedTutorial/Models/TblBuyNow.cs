using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblBuyNow
{
    public int BuyNowId { get; set; }

    public int AddressId { get; set; }

    public int CartId { get; set; }

    public int ShipId { get; set; }

    public int PaymentTypesId { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual TblAddress Address { get; set; } = null!;

    public virtual TblCart Cart { get; set; } = null!;

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual TblPaymentType PaymentTypes { get; set; } = null!;

    public virtual TblShip Ship { get; set; } = null!;

    public virtual ICollection<TblPurchase> TblPurchases { get; } = new List<TblPurchase>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblAddress
{
    public int AddressId { get; set; }

    public int ProductId { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string PinCode { get; set; } = null!;

    public string? DeliverAddress { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual TblProduct Product { get; set; } = null!;

    public virtual ICollection<TblBuyNow> TblBuyNows { get; } = new List<TblBuyNow>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

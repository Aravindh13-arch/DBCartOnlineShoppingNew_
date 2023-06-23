using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblPaymentType
{
    public int PaymentTypesId { get; set; }

    public string TypesOfPayment { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblBuyNow> TblBuyNows { get; } = new List<TblBuyNow>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

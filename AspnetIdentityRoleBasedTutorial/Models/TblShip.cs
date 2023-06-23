using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblShip
{
    public int ShipId { get; set; }

    public string TypesOfShip { get; set; } = null!;

    public int TypesOfAmount { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblBuyNow> TblBuyNows { get; } = new List<TblBuyNow>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

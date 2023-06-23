using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblSize
{
    public int SizeId { get; set; }

    public string TypesOfSize { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblCart> TblCarts { get; } = new List<TblCart>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

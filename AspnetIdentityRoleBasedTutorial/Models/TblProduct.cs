﻿using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductCode { get; set; }

    public int UnitId { get; set; }

    public decimal Rate { get; set; }

    public string Image { get; set; } = null!;

    public string? Description { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual TblUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblBuyNow> TblBuyNows { get; } = new List<TblBuyNow>();

    public virtual ICollection<TblCart> TblCarts { get; } = new List<TblCart>();

    public virtual ICollection<TblInventory> TblInventories { get; } = new List<TblInventory>();

    public virtual ICollection<TblWishList> TblWishLists { get; } = new List<TblWishList>();

    public virtual TblUnit Unit { get; set; } = null!;

    public virtual TblUser? UpdatedByNavigation { get; set; }
}

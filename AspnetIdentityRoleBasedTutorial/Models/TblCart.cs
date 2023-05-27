﻿using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblCart
{
    public int CartId { get; set; }

    public int? ProductId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Rate { get; set; }

    public short Status { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual TblProduct? Product { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

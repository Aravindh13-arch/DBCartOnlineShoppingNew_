using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblOrderItem
{
    public int OrderItemId { get; set; }

    public int CartId { get; set; }

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual TblCart Cart { get; set; } = null!;

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

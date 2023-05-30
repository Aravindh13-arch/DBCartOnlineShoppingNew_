using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();

    public virtual ICollection<TblSubCategory> TblSubCategories { get; } = new List<TblSubCategory>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

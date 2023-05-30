using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblSubCategory
{
    public int SubCategoryId { get; set; }

    public int CategoryId { get; set; }

    public string SubCategoryName { get; set; } = null!;

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<TblProduct> TblProducts { get; } = new List<TblProduct>();

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

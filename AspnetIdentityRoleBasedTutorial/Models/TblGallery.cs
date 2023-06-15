using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class TblGallery
{
    public int GalleryId { get; set; }

    public int? ProductId { get; set; }

    public string ThumbImage { get; set; } = null!;

    public string Image { get; set; } = null!;

    public short Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; }

    public virtual AspNetUser CreatedByNavigation { get; set; } = null!;

    public virtual TblProduct? Product { get; set; }

    public virtual AspNetUser? UpdatedByNavigation { get; set; }
}

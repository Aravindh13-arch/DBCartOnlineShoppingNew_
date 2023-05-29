using System;
using System.Collections.Generic;

namespace OnlineShoppingProject.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? ProfilePicture { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; } = new List<AspNetUserToken>();

    public virtual ICollection<TblAddress> TblAddressCreatedByNavigations { get; } = new List<TblAddress>();

    public virtual ICollection<TblAddress> TblAddressUpdatedByNavigations { get; } = new List<TblAddress>();

    public virtual ICollection<TblBrand> TblBrandCreatedByNavigations { get; } = new List<TblBrand>();

    public virtual ICollection<TblBrand> TblBrandUpdatedByNavigations { get; } = new List<TblBrand>();

    public virtual ICollection<TblBuyNow> TblBuyNowCreatedByNavigations { get; } = new List<TblBuyNow>();

    public virtual ICollection<TblBuyNow> TblBuyNowUpdatedByNavigations { get; } = new List<TblBuyNow>();

    public virtual ICollection<TblCart> TblCartCreatedByNavigations { get; } = new List<TblCart>();

    public virtual ICollection<TblCart> TblCartUpdatedByNavigations { get; } = new List<TblCart>();

    public virtual ICollection<TblCategory> TblCategoryCreatedByNavigations { get; } = new List<TblCategory>();

    public virtual ICollection<TblCategory> TblCategoryUpdatedByNavigations { get; } = new List<TblCategory>();

    public virtual ICollection<TblInventory> TblInventoryCreatedByNavigations { get; } = new List<TblInventory>();

    public virtual ICollection<TblInventory> TblInventoryUpdatedByNavigations { get; } = new List<TblInventory>();

    public virtual ICollection<TblProduct> TblProductCreatedByNavigations { get; } = new List<TblProduct>();

    public virtual ICollection<TblProduct> TblProductUpdatedByNavigations { get; } = new List<TblProduct>();

    public virtual ICollection<TblPurchase> TblPurchaseCreatedByNavigations { get; } = new List<TblPurchase>();

    public virtual ICollection<TblPurchase> TblPurchaseUpdatedByNavigations { get; } = new List<TblPurchase>();

    public virtual ICollection<TblUnit> TblUnitCreatedByNavigations { get; } = new List<TblUnit>();

    public virtual ICollection<TblUnit> TblUnitUpdatedByNavigations { get; } = new List<TblUnit>();

    public virtual ICollection<TblWishList> TblWishListCreatedByNavigations { get; } = new List<TblWishList>();

    public virtual ICollection<TblWishList> TblWishListUpdatedByNavigations { get; } = new List<TblWishList>();

    public virtual ICollection<AspNetRole> Roles { get; } = new List<AspNetRole>();
}

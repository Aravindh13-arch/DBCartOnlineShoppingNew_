﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace OnlineShoppingProject.Models;

public partial class OnlineShopDbContext : DbContext
{
    public OnlineShopDbContext()
    {
    }
    private IConfiguration _configuration;
    public OnlineShopDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<TblAddress> TblAddresses { get; set; }

    public virtual DbSet<TblBuyNow> TblBuyNows { get; set; }

    public virtual DbSet<TblCart> TblCarts { get; set; }

    public virtual DbSet<TblInventory> TblInventories { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblPurchase> TblPurchases { get; set; }

    public virtual DbSet<TblUnit> TblUnits { get; set; }

    public virtual DbSet<TblWishList> TblWishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConcurrencyStamp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NormalizedName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.ClaimType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClaimValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ConcurrencyStamp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NormalizedEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NormalizedUserName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SecurityStamp)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.ClaimType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClaimValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.LoginProvider)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProviderKey)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProviderDisplayName).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoginProvider)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("tblAddress");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.DeliverAddress)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("deliverAddress");
            entity.Property(e => e.PinCode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("pinCode");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblAddressCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.TblAddresses)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAddress_tblproduct_productId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblAddressUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblBuyNow>(entity =>
        {
            entity.HasKey(e => e.BuyNowId);

            entity.ToTable("tblBuyNow");

            entity.Property(e => e.BuyNowId).HasColumnName("buyNowId");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.PayementTypes).HasColumnName("payementTypes");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("rate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.Address).WithMany(p => p.TblBuyNows)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBuyNow_tblAddress_Address");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblBuyNowCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.TblBuyNows)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBuyNow_tblproduct_productId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblBuyNowUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblCart>(entity =>
        {
            entity.HasKey(e => e.CartId);

            entity.ToTable("tblCart");

            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("rate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblCartCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.TblCarts).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblCartUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblInventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId);

            entity.ToTable("tblInventory");

            entity.Property(e => e.InventoryId).HasColumnName("inventoryId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblInventoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.TblInventories).HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblInventoryUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("tblProduct");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productCode");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("rate");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Unit).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblProductUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblPurchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId);

            entity.ToTable("tblPurchase");

            entity.Property(e => e.BuyNowId).HasColumnName("buyNowId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.BuyNow).WithMany(p => p.TblPurchases)
                .HasForeignKey(d => d.BuyNowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPurchase_tblbuyNow_buyNowId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblPurchaseCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblPurchaseUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId);

            entity.ToTable("tblUnit");

            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UnitName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unitName");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblUnitCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblUnitUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        modelBuilder.Entity<TblWishList>(entity =>
        {
            entity.HasKey(e => e.WishListId);

            entity.ToTable("tblWishList");

            entity.Property(e => e.WishListId).HasColumnName("wishListId");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblWishListCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Product).WithMany(p => p.TblWishLists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblWishList_tblproduct_tblproductId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblWishListUpdatedByNavigations).HasForeignKey(d => d.UpdatedBy);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

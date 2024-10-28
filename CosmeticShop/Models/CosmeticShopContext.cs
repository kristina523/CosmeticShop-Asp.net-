using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.Models;

public partial class CosmeticShopContext : DbContext
{
    public CosmeticShopContext()
    {
    }

    public CosmeticShopContext(DbContextOptions<CosmeticShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsFromBrand> ProductsFromBrands { get; set; }

    public virtual DbSet<ProductsInCategory> ProductsInCategories { get; set; }

    public virtual DbSet<ProductsInOrder> ProductsInOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=krolik\\SQLEXPRESS;Initial Catalog=CosmeticShop;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC27D1642A0B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Names)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC274360CB28");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Names)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC27EB28EA7D");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Order_Status");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__User_ID__5CD6CB2B");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prices__3214EC273E1652EB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dates)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Price");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Product).WithMany(p => p.Prices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Prices__Product___5165187F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2778EDF435");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descriptions).HasColumnType("text");
            entity.Property(e => e.Names)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductsFromBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC27B1E04094");

            entity.ToTable("Products_from_Brands");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("Brand_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Brand).WithMany(p => p.ProductsFromBrands)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products___Brand__59FA5E80");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsFromBrands)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Products___Produ__59063A47");
        });

        modelBuilder.Entity<ProductsInCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC27BE21D5FF");

            entity.ToTable("Products_in_Categories");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("Category_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsInCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products___Categ__5629CD9C");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsInCategories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Products___Produ__5535A963");
        });

        modelBuilder.Entity<ProductsInOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC27810A2ECE");

            entity.ToTable("Products_in_Orders");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductsInOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Products___Order__5FB337D6");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsInOrders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Products___Produ__60A75C0F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27604EFA78");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Passwords)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Roles)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

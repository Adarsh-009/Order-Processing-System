using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderProcessingSystem.Models;

public partial class OrderDbContext : DbContext
{
    public OrderDbContext()
    {
    }

    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderPro__D3B9D36CB5F6464E");

            entity.Property(e => e.Rate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Size).HasMaxLength(10);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderProd__Order__787EE5A0");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderProd__Produ__778AC167");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07D682D3FF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System.Xml.Schema;
using eCommerce.Models.Entities;
using eCommerce.Services.Database.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
    public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }
    public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {




        modelBuilder.Entity<SalesInvoiceItem>(entity =>
        {
            entity.HasOne(x => x.SalesInvoice).WithMany(x => x.SalesInvoiceItems)
            .HasForeignKey(x => x.SalesInvoiceId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_SalesInvoiceItems_SalesInvoices");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesInvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoiceItems_Products");

        });

        modelBuilder.Entity<SalesInvoice>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoices_Users");

            entity.HasOne(d => d.Order).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_SalesInvoice_Orders");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesInvoices_Warehouses");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.Username).IsUnique();


        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderItems_Order");

            entity.HasOne(x => x.Product).WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasOne(x => x.Customer)
            .WithMany(x => x.ProductReviews)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductReviews_Customers");

            entity.HasOne(x => x.Product).WithMany(x => x.ProductReviews)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductReviews_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasOne(x => x.UnitOfMeasure)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.UnitOfMeasureId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Products_UnitOfMeasures");

            entity.HasOne(x => x.ProductType)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Products_ProductTypes");
        });

        modelBuilder.Entity<PurchaseInvoiceItem>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseInvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoiceItems_Products");

            entity.HasOne(d => d.PurchaseInvoice).WithMany(p => p.PurchaseInvoiceItems)
                .HasForeignKey(d => d.PurchaseInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoiceItems_PurchaseInvoices");
        });

        modelBuilder.Entity<PurchaseInvoice>(entity =>
        {
            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseInvoices)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoices_Suppliers");

            entity.HasOne(d => d.User).WithMany(p => p.PurchaseInvoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoices_Users");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.PurchaseInvoices)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseInvoices_Warehouses");
        });


    }




}

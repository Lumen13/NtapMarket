using Microsoft.EntityFrameworkCore;
using NtapMarket.Data.DBModel;
using System;
using System.Collections.Generic;
using System.Text;
using NtapMarket.Data.ObjectModel;

namespace NtapMarket.Data.EF
{
    public class DBContext : DbContext
    {

        public DBContext(string connectionString) : base(_getContextOptions(connectionString))
        {

        }

        private static DbContextOptions<DBContext> _getContextOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<Seller> Sellers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>(builder => 
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(100);
                builder.Property(x => x.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Purchaser>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(100);
                builder.Property(x => x.Email).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(250);
                builder.Property(x => x.MarketingInfo).HasMaxLength(1000);
                builder.HasOne<Seller>()
                    .WithMany()
                    .HasForeignKey(fk => fk.SellerId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<ProductCategory>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ProductCategoryId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.Property(x => x.ProductCategoryId)
                    .IsRequired(false);
            });

            modelBuilder.Entity<ProductAttribute>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(1000);
                builder.Property(x => x.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<ProductAttributeValue>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Value).HasMaxLength(1000);
                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ProductId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<ProductAttribute>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ProductAttributeId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductCategory>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasMaxLength(200);
                builder.Property(x => x.Description).HasMaxLength(1000);
                builder.HasOne<ProductCategory>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ParentId).IsRequired(false)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductImage>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.ImageURL).HasMaxLength(5000);
                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ProductId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.Ignore(x => x.ImageFile);
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasOne<Purchaser>()
                    .WithMany()
                    .HasForeignKey(fk => fk.PurchaserId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<Seller>()
                    .WithMany()
                    .HasForeignKey(fk => fk.SellerId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderElement>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasOne<Order>()
                    .WithMany()
                    .HasForeignKey(fk => fk.OrderId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(fk => fk.ProductId)
                    .HasPrincipalKey(pk => pk.Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

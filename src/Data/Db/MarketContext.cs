using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechMarket.Data.Db.Entities;

namespace TechMarket.Data;

public class MarketContext : IdentityDbContext<UserEntity>
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    public DbSet<CompanyEntity> Companies => Set<CompanyEntity>();

    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    public MarketContext(DbContextOptions<MarketContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.OnModelCreating(builder);

        builder.Entity<CompanyEntity>(entity =>
        {
            entity.ToTable("company");

            entity.Property(x => x.Id).HasColumnName("id").IsRequired(true);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).HasColumnName("name").IsRequired(true);

            entity.HasMany(x => x.Products).WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);
        });

        builder.Entity<CategoryEntity>(entity =>
        {
            entity.ToTable("category");

            entity.Property(x => x.Id).HasColumnName("id").IsRequired(true);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).HasColumnName("name").IsRequired(true);

            entity.HasMany(x => x.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
        });

        builder.Entity<ProductEntity>(entity =>
        {
            entity.ToTable("product");

            entity.Property(x => x.Id).HasColumnName("id").IsRequired(true);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name).HasColumnName("name").IsRequired(true);

            entity.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired(true);

            entity
                .HasOne(x => x.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.CompanyId);

            entity.Property(x => x.CategoryId).HasColumnName("category_id").IsRequired(true);

            entity
                .HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.CategoryId);

            entity.Property(x => x.Price).HasColumnName("price").IsRequired(true);

            entity.Property(x => x.Discription).HasColumnName("discription").IsRequired(false);

            entity.HasMany(x => x.Orders).WithMany(x => x.Products);
        });

        builder.Entity<OrderEntity>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(x => x.Id).HasColumnName("id").IsRequired(true);

            entity.HasKey(x => x.Id);

            entity.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired(true);

            entity
                .HasOne(x => x.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(x => x.CustomerId);

            entity.Property(x => x.Status).HasColumnName("status").HasConversion<int>().IsRequired(true);

            entity.Property(x => x.DateTimeCreated).HasColumnName("date_time_created").IsRequired(true);

            entity.Property(x => x.DateTimeClose).HasColumnName("date_time_close").IsRequired(false);

            entity.HasMany(x => x.Products).WithMany(x => x.Orders);
        });
    }
}
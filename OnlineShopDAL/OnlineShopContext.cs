using OnlineShopDAL.Entities;

namespace OnlineShopDAL;
using Microsoft.EntityFrameworkCore;

public class OnlineShopContext : DbContext
{

    public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }
    
    public virtual DbSet<CartEntity> Carts { get; set; }
    
    public virtual DbSet<CategoryEntity> Categories { get; set; }
    
    public virtual DbSet<CustomerEntity> Customers { get; set; }
    
    public virtual DbSet<ItemEntity> Items { get; set; }
    
    public virtual DbSet<OrderEntity> Orders { get; set; }
    
    public virtual DbSet<PhotoEntity> Photos { get; set; }
    
    public virtual DbSet<ReviewEntity> Reviews { get; set; }


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEntity>()
            .HasMany(item => item.Photos)
            .WithOne(photo => photo.Item)
            .HasForeignKey(photo => photo.ItemEntityId);

        modelBuilder.Entity<ReviewEntity>()
            .HasMany(review => review.Photos)
            .WithOne(photo => photo.Review)
            .HasForeignKey(photo => photo.ReviewEntityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}
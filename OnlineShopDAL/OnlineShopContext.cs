using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.ItemTypes;

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
            .WithOne() //photo => photo.Item
            .HasForeignKey(photo => photo.ItemId);

        modelBuilder.Entity<ReviewEntity>()
            .HasMany(review => review.Photos)
            .WithOne() //photo => photo.Review
            .HasForeignKey(photo => photo.ReviewId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemEntity>()
            .HasDiscriminator<string>("discriminator")
            .HasValue<ItemEntity>("BaseItem")
            .HasValue<ItemElectronicsEntity>("Electronics")
            .HasValue<ItemClothesEntity>("Clothes")
            .HasValue<ItemDecorationsEntity>("Decorations")
            .HasValue<ItemSportEntity>("Sport");


        /*
    modelBuilder.Entity<PhotoEntity>()
        .HasOne(p => p.Item)
        .WithMany(i => i.Photos)
        .HasForeignKey(p => p.ItemEntityId);

    modelBuilder.Entity<PhotoEntity>()
        .HasOne(p => p.Review)
        .WithMany(r => r.Photos)
        .HasForeignKey(p => p.ReviewEntityId);
    */

    }
    
}
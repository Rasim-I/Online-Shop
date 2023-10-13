using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Carts")]
public class CartEntity
{
    public Guid Id { get; set; }
    
    //[ForeignKey(nameof(CustomerEntity))]
    public Guid CustomerId { get; set; }
    
    public int Price { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public Dictionary<ItemEntity, int> Items { get; set; }
    


}
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Carts")]
public class CartEntity
{
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(CustomerEntity))]
    public CustomerEntity Customer { get; set; }
    
    public int? Price { get; set; }
    
    //[ForeignKey(nameof(CartItems))]
    public List<CartItemEntity>? CartItems { get; set; }
    
}
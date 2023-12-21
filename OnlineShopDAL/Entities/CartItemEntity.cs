using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;
[Table("CartItem")]
public class CartItemEntity
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(CartEntity))]
    public Guid CartId { get; set; }

    public int Quantity { get; set; }

    [ForeignKey(nameof(ItemEntity))]
    public ItemEntity Item { get; set; }
    public Guid ItemId { get; set; }
}
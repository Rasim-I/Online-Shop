using System.ComponentModel.DataAnnotations.Schema;
using OnlineShopDAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopDAL.Entities;

[Table("Orders")]
public class OrderEntity
{
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(CustomerEntity))]
    public CustomerEntity Customer { get; set; }
    
    [ForeignKey(nameof(CartItemEntity))]
    public List<CartItemEntity> Items { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    [EnumDataType(typeof(Status))]
    public Status Status { get; set; }

}
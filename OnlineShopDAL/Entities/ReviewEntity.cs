using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.Entities;

[Table("Reviews")]
public class ReviewEntity
{
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(CustomerEntity))]
    public CustomerEntity Customer { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public ItemEntity Item { get; set; }
    
    public string Text { get; set; }
    
    [EnumDataType(typeof(Stars))]
    public Stars Stars { get; set; }
    
    public DateTime ReviewDate { get; set; }
    
    [ForeignKey(nameof(PhotoEntity))]
    public List<PhotoEntity>? Photos { get; set; }



}
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Items")]
public class ItemEntity
{
    public Guid Id { get; set; }
    
    public int Price { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Quantity { get; set; }
    
    [ForeignKey(nameof(PhotoEntity))]
    public List<PhotoEntity> Photos { get; set; }
    
    [ForeignKey(nameof(CategoryEntity))]
    public CategoryEntity Category { get; set; }

}

using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Categories")]
public class CategoryEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public ItemEntity Item { get; set; }
    
    [ForeignKey(nameof(PhotoEntity))]
    public PhotoEntity Photo { get; set; }
    
    [ForeignKey(nameof(CategoryEntity))]
    public List<CategoryEntity> SubCategories { get; set; }
    
    [ForeignKey(nameof(CategoryEntity))]
    public CategoryEntity PrimaryCategory { get; set; }
    

}
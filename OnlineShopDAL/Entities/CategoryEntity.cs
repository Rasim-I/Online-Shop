using System.ComponentModel.DataAnnotations.Schema;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.Entities;

[Table("Categories")]
public class CategoryEntity
{
    public Guid Id { get; set; }
    
    public CategoryNames Name { get; set; }

    [ForeignKey(nameof(CategoryEntity))]
    public List<CategoryEntity> SubCategories { get; set; }
    
    

}
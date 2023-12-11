using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.Entities;

[Table("Categories")]
public class CategoryEntity
{
    public Guid Id { get; set; }
    
    //public CategoryNames Name { get; set; }
    
    [ForeignKey(nameof(CategoryEntity))]
    public Guid RootCategory { get; set; }
    
    public bool IsRoot { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public ItemEntity Item { get; set; }
    //public Guid ItemId { get; set; }

}
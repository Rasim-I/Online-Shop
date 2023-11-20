using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Photos")]
public class PhotoEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public Guid ItemEntityId { get; set; }
    public ItemEntity Item { get; set; }
    
    [ForeignKey(nameof(ItemEntity))]
    public Guid ReviewEntityId { get; set; }
    public ReviewEntity Review { get; set; }

}
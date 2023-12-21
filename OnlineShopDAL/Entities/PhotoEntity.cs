using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Photos")]
public class PhotoEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    
    
    //[ForeignKey(nameof(ItemEntity))]
    public Guid? ItemId { get; set; }
    //public ItemEntity Item { get; set; }
    
    
    //[ForeignKey(nameof(ReviewEntity))]
    public Guid? ReviewId { get; set; }
    //public ReviewEntity Review { get; set; }
    
    public bool IsMain { get; set; }

}
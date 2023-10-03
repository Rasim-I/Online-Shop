using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopDAL.Entities;

[Table("Photos")]
public class PhotoEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    
    
}
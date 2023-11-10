using OnlineShopLogic.Models;

namespace OnlineShop.Models;

public class ItemWebModel
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Photo> Photos;
    public Guid CategoryId { get; set; }
    
    
}
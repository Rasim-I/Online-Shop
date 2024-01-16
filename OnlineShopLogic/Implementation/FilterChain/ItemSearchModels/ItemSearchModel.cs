
namespace OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;

public class ItemSearchModel
{
    public List<string> Brands { get; set; }
    
    public string Name { get; set; }
    
    public int MinPrice { get; set; }
    
    public int MaxPrice { get; set; }
    
}
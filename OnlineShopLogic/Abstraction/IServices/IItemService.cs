using OnlineShopLogic.Models;

namespace OnlineShopLogic.Abstraction.IServices;

public interface IItemService
{
    public bool FillDatabase();
    
    
    public List<Item> GetItems();
    public Item GetItem(Guid itemId);
    public List<Item> GetItemsByCategory(string categoryName);
    public Category? GetCategoryByName(string categoryName);

}
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Abstraction.IServices;

public interface IItemService
{
    public bool FillDatabase();
    
    
    public List<Item> GetItems();
    public Item GetItem(Guid itemId);
    public List<Item> GetItemsByCategory(string categoryName);
    public Category? GetCategoryByName(string categoryName);
    public List<Item> GetItemsByBrand(string brandName); 
    public List<ItemElectronics> GetElectronicsByCpuModel(string cpuModel);
    public List<ItemElectronics> GetElectronicsByMemoryCapacity(string memoryCapacity);
    public List<ItemElectronics> MapToItemElectronics(List<Item> items);
    public List<Item> GetItemsMock();
}
using OnlineShopModels.Models;
using OnlineShopModels.Models.Enums;
using OnlineShopModels.Models.ItemTypes;


namespace OnlineShopLogic.Abstraction.IServices;

public interface IItemService
{
    public bool FillDatabase();
    
    
    public List<Item> GetItems();
    public Item GetItem(Guid itemId);
    public List<Item> GetItemsByCategory(string categoryName);
    public Category? GetCategoryByName(string categoryName);
    public Category? GetCategory(OnlineShopDAL.Entities.Enums.CategoryName categoryName);
    public List<Item> GetItemsByCategoryName(CategoryName category);
    public List<Item> GetItemsByBrand(string brandName); 
    public List<ItemElectronics> GetElectronicsByCpuModel(string cpuModel);
    public List<ItemElectronics> GetElectronicsByMemoryCapacity(string memoryCapacity);
    public List<ItemElectronics> MapToItemElectronics(List<Item> items);
    public List<ItemSport> MapToItemSport(List<Item> items);
    public List<ItemClothes> MapToItemClothes(List<Item> items);
    public List<ItemDecorations> MapToItemDecorations(List<Item> items);
    public List<Item> GetItemsMock();
}
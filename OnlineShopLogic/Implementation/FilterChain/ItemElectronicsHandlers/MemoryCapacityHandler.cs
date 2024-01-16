using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemElectronicsHandlers;

public class MemoryCapacityHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {
        if (itemSearchModel is ItemElectronicsSearchModel electronicsSearchModel)
        {
            List<ItemElectronics> allItems = itemService.MapToItemElectronics(items);
            List<ItemElectronics> filteredItems = new List<ItemElectronics>();

            foreach (var memoryCapacity in electronicsSearchModel.MemoryCapacities)
            {
                foreach (var item in allItems)
                {
                    if (item.MemoryCapacity.Equals(memoryCapacity))
                    {
                        filteredItems.Add(item);
                    }
                }
            }

            items = items.Intersect(filteredItems, new ItemComparer()).ToList();
            return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
            
        }
        
        return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
    }
}
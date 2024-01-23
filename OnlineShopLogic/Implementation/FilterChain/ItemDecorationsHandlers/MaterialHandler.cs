using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemDecorationsHandlers;

public class MaterialHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {
        if (itemSearchModel is ItemDecorationsSearchModel decorationsSearchModel)
        {
            List<ItemDecorations> allItems = itemService.MapToItemDecorations(items);
            List<ItemDecorations> filteredItems = new List<ItemDecorations>();

            foreach (var material in decorationsSearchModel.Materials)
            {
                foreach (var item in allItems)
                {
                    if (item.Material.Equals(material))
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
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemSportHandlers;

public class ActivityHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {
        if (itemSearchModel is ItemSportSearchModel sportSearchModel &&
            sportSearchModel.Activities.Count != 0)
        {
            List<ItemSport> allItems = itemService.MapToItemSport(items);
            List<ItemSport> filteredItems = new List<ItemSport>();

            foreach (var activity in sportSearchModel.Activities)
            {
                foreach (var item in allItems)
                {
                    if (item.Activity.Equals(activity))
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
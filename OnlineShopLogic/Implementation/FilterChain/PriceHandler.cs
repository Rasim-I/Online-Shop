using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.FilterChain;

public class PriceHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {
        List<Item> allItems = items;
        List<Item> filteredItems = new List<Item>();

        foreach (var item in allItems)
        {
            if (itemSearchModel.MinPrice <= item.Price && item.Price <= itemSearchModel.MaxPrice)
            {
                filteredItems.Add(item);
            }
        }

        items = items.Intersect(filteredItems, new ItemComparer()).ToList();
        return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
    }
}
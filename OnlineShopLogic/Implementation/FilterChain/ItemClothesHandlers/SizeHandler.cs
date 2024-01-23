using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemClothesHandlers;

public class SizeHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel,
        List<Item> items)
    {
        //List<Item> itemsWithCpuModel = items;
        if (itemSearchModel is ItemClothesSearchModel clothesSearchModel)
        {
            List<ItemClothes> allItems = itemService.MapToItemClothes(items);
            List<ItemClothes> filteredItems = new List<ItemClothes>();

            foreach (var size in clothesSearchModel.Sizes)
            {
                foreach (var item in allItems)
                {
                    if (item.Size.Equals(size))
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

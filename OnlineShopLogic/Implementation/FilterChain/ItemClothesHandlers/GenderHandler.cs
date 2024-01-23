using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemClothesHandlers;

public class GenderHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel,
        List<Item> items)
    {
        if (itemSearchModel is ItemClothesSearchModel clothesSearchModel)
        {
            List<ItemClothes> allItems = itemService.MapToItemClothes(items);
            List<ItemClothes> filteredItems = new List<ItemClothes>();

            foreach (var item in allItems)
            {
                if (item.Gender.Equals(clothesSearchModel.Gender))
                {
                    filteredItems.Add(item);
                }
            }

            items = items.Intersect(filteredItems, new ItemComparer()).ToList();
            return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
        }

        return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
    }
}
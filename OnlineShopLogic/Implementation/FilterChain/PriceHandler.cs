﻿using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.FilterChain;

public class PriceHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {

        if (!ValidatePrice(itemSearchModel.MinPrice, itemSearchModel.MaxPrice))
        {
            return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
        }

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

    private bool ValidatePrice(int minPrice, int maxPrice)
    {
        if (minPrice < 0 || minPrice > maxPrice)
            return false;
        else if (minPrice == 0 && maxPrice == 0)
        {
            return false;
        }
        else
            return true;
    }
    
}
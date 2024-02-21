using System.Runtime.CompilerServices;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopLogic.Implementation.Services;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.FilterChain.ItemElectronicsHandlers;

public class CpuModelHandler : QueryHandler
{

    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items)
    {
        //List<Item> itemsWithCpuModel = items;
        if (itemSearchModel is ItemElectronicsSearchModel electronicsSearchModel &&
            electronicsSearchModel.CpuModels.Count() != 0)
        {

            List<ItemElectronics> allItems = itemService.MapToItemElectronics(items);
            List<ItemElectronics> filteredItems = new List<ItemElectronics>();

            foreach (var cpuModel in electronicsSearchModel.CpuModels)
            {
                foreach (var item in allItems)
                {
                    if (item.CpuModel.Equals(cpuModel))
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
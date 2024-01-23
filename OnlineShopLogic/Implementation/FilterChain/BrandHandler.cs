using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.FilterChain;

public class BrandHandler : QueryHandler
{
    public override List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel,
        List<Item> items)
    {
        List<Item> allItems = items; //itemService.GetItems();
        List<Item> filteredItems = new List<Item>();
        
        foreach (var brand in itemSearchModel.Brands)
        {
            foreach (var item in allItems)
            {
                if (item.Brand.Equals(brand) && !filteredItems.Contains(item))
                {
                    filteredItems.Add(item);
                }
            }
        }

        items = items.Intersect(filteredItems, new ItemComparer()).ToList();
        return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;

        //List<Item> itemsBrand = new List<Item>();
        //itemsBrand.AddRange(itemService.GetItemsByBrand(itemSearchModel.Brand));
        //items = items.Intersect(itemsBrand, new ItemComparer()).ToList();
        //return Successor?.HandleRequest(itemService, itemSearchModel, items) ?? items;
    }


}
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.FilterChain;

public abstract class QueryHandler
{
    public QueryHandler Successor { get; set; }

    public abstract List<Item> HandleRequest(IItemService itemService, ItemSearchModel itemSearchModel, List<Item> items);
}
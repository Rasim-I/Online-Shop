using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.FilterChain;

public class ItemComparer : IEqualityComparer<Item>
{
    public bool Equals(Item x, Item y)
    {
        return x.Id == y.Id;
    }

    public int GetHashCode(Item obj)
    {
        return obj.Id.GetHashCode();
    }
}
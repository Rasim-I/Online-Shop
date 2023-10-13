using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class ItemRepository : Repository<ItemEntity, Guid>, IItemRepository
{
    public ItemRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
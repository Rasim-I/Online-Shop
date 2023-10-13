using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface IItemRepository : IRepository<ItemEntity, Guid>
{
    
}
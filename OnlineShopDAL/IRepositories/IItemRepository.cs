using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface IItemRepository : IRepository<ItemEntity, Guid>
{
    public IEnumerable<ItemEntity> GetAll_IncludeAll();
    public ItemEntity? GetById(Guid itemId);
}
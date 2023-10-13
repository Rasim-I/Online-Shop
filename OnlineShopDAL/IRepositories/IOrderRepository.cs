using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface IOrderRepository : IRepository<OrderEntity, Guid>
{
    
}
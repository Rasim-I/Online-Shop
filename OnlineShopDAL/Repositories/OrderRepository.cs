using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class OrderRepository : Repository<OrderEntity, Guid>, IOrderRepository
{
    public OrderRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
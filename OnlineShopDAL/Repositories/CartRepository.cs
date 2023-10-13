using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CartRepository : Repository<CartEntity, Guid>, ICartRepository
{
    public CartRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
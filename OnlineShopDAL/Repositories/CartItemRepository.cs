using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CartItemRepository : Repository<CartItemEntity, Guid>, ICartItemRepository
{
    public CartItemRepository(OnlineShopContext context) : base(context)
    {
        
    }
}
using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface ICartItemRepository : IRepository<CartItemEntity, Guid>
{
    public void UpdateDetached(CartItemEntity cartItemEntity);
}
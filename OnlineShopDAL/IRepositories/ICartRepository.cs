using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface ICartRepository : IRepository<CartEntity, Guid>
{
    public CartEntity GetByCustomer(Guid customerId);
    public void UpdateDetached(CartEntity cart);
}
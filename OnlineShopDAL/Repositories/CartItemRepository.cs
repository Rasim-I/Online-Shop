using Microsoft.EntityFrameworkCore;
using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CartItemRepository : Repository<CartItemEntity, Guid>, ICartItemRepository
{
    public CartItemRepository(OnlineShopContext context) : base(context)
    {
        
    }

    public void UpdateDetached(CartItemEntity cartItemEntity)
    {
        CartItemEntity cartItemToChange = db.CartItems.Where(ci => ci.Id.Equals(cartItemEntity.Id)).FirstOrDefault();

        db.Entry(cartItemToChange).State = EntityState.Detached;
        cartItemToChange = cartItemEntity;
        db.Entry(cartItemToChange).State = EntityState.Modified;
    }
}
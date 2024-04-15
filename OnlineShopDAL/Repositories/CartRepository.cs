using Microsoft.EntityFrameworkCore;
using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CartRepository : Repository<CartEntity, Guid>, ICartRepository
{
    public CartRepository(OnlineShopContext context) : base(context)
    {
        
    }

    public CartEntity GetByCustomer(Guid customerId)
    {
        IQueryable<CartEntity> cartToCheck = db.Carts
            .Include(c => c.CartItems).ThenInclude(ci => ci.Item).ThenInclude(it => it.Photos)
            .Include(c => c.Customer)
            .Where(c => c.Customer.Id.Equals(customerId));

        //var carts = cartToCheck;
        
        if (cartToCheck.Any())
        {
            return cartToCheck.SingleOrDefault();
        }
        else
        {
            return null; //
        }
    }

    public void UpdateDetached(CartEntity cartEntity)
    {
        CartEntity cart = db.Carts.Where(c => c.Id.Equals(cartEntity.Id)).FirstOrDefault();
        //db.Entry(cart).State = EntityState.Detached;
        //db.Carts.Attach(cartEntity);
        //db.Attach(cartEntity);
        //cart = cartEntity;
        db.Entry(cart).State = EntityState.Detached;
        cart = cartEntity;
        db.Entry(cart).State = EntityState.Modified;
        //db.SaveChanges();
    }
    
    
    
}
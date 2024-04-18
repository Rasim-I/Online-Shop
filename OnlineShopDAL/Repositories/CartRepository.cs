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

    public void AddCartItem(CartItemEntity cartItem, Guid itemId, Guid cartId)
    {
        try
        {
            //ItemEntity itemToAdd = _unitOfWork.Items.Find(i => i.Id.Equals(itemId)).FirstOrDefault();
            ItemEntity item = db.Items.Where(i => i.Id.Equals(itemId)).FirstOrDefault();
            CartEntity cart = db.Carts.Where(c => c.Id.Equals(cartId)).FirstOrDefault();
            //db.Entry(item).State = EntityState.Detached;
            //db.Entry(item).State = EntityState.Modified;
            cartItem.Cart = cart;
            cartItem.Item = item;
            db.CartItems.Add(cartItem); //Continue
            //.Save(); //problem with Item id. Maybe it needs and actual Item. in that case, move this logic to CartItemRepository and detach Item before adding.
            //return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //return false;
            throw;
        }
    }
    
    
}
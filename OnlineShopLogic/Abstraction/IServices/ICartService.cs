using OnlineShopModels.Models;

namespace OnlineShopLogic.Abstraction.IServices;

public interface ICartService
{
    public Cart GetCart(Guid customerId);

    public bool UpdateCart(Cart cartToUpdate);

    public bool UpdateCartItemQuantity(CartItem cartItem);

    public bool RemoveCartItem(Guid cartItemId);

    public bool AddCartItem(Guid itemId, Cart cart);
}
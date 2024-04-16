using Microsoft.AspNetCore.Mvc;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.ItemParameters;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace Online_Shop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    private readonly ICartService _cartService;

    private Cart _cart;

    public Cart Cart
    {
        get
        {
            //_cart == null ? GetTestCart() : _cart;
            if (_cart == null)
            {
                Guid testUserId = Guid.Parse("55047486-7466-4d64-b568-674c7db20ffd");
                _cart = _cartService.GetCart(testUserId);
            }

            return _cart;
        }
        set { _cart = value; }
    }

    public CartController(ILogger<CartController> logger, ICartService cartService)
    {
        _logger = logger;
        _cartService = cartService;
    }

    public Cart GetTestCart()
    {
        /*
            ItemElectronics itemElectronics = new ItemElectronics()
            {
                Id = Guid.Parse("c703c545-2c99-4476-947f-095c835aad6d"), Price = 23, Brand = ItemElectronicsParameters.HPBrand, Description = "description 111",
                Name = "Hp laptop0", CpuModel = ItemElectronicsParameters.IntelCpuModel,
                MemoryCapacity = ItemElectronicsParameters.Memory128,
                Photos = new List<Photo>() { new Photo("hp test", "/Item_Images/Blue.png") {IsMain = true} }
            };
            ItemSport itemSport = new ItemSport()
            {
                Id = Guid.Parse("b0ce4e94-e71d-4787-9320-b12853eb9d9c"), Price = 10, Brand = ItemSportParameters.DonicBrand, Description = "description 2312",
                Name = "Racket Donic43", Activity = ItemSportParameters.TableTennisActivity,
                Photos = new List<Photo>() { new Photo("Racket Photo", "/Item_Images/Green.png") { IsMain = true} }
            };
            
            CartItem cartItem1 = new CartItem() { Id = Guid.Parse("f3ceb6c0-61c4-4e14-9b38-357b8edfc88b"), Item = itemElectronics, Quantity = 2, ItemId = itemElectronics.Id };
            CartItem cartItem2 = new CartItem() { Id = Guid.Parse("9afd55c4-0f8d-4c5a-92a3-c62451b85a11"), Item = itemSport, Quantity = 1, ItemId = itemSport.Id };
            Cart cart = new Cart() { Id = Guid.NewGuid(), Price = 342, CartItems = new List<CartItem>(){cartItem1, cartItem2}};
            
        */

        Guid testUserId = Guid.Parse("55047486-7466-4d64-b568-674c7db20ffd");
        Cart cart = _cartService.GetCart(testUserId);

        return cart;
    }


    public Cart MoreQuantity(Guid cartItemId)
    {
        //Cart cartToUpdate = cart;
        CartItem cartItem = Cart.CartItems.Where(cartItem => cartItem.Id.Equals(cartItemId)).FirstOrDefault();
        cartItem.Quantity++;

        bool result = _cartService.UpdateCartItemQuantity(cartItem);
        Console.WriteLine(result + "--------------------------");
        return Cart;
    }

    public Cart LessQuantity(Guid cartItemId)
    {
        CartItem cartItem = Cart.CartItems.Where(ci => ci.Id.Equals(cartItemId)).FirstOrDefault();

        if (cartItem.Quantity == 1)
        {
            RemoveItem(cartItemId, cartItem);
        }
        else
        {
            cartItem.Quantity--;
            _cartService.UpdateCartItemQuantity(cartItem);
        }

        return Cart;
    }

    public Cart RemoveItem(Guid cartItemId, CartItem? cartItem)
    {
        if (cartItem != null)
        {
            Cart.CartItems.Remove(cartItem);
            _cartService.RemoveCartItem(cartItem.Id);
        }
        else
        {
            cartItem = Cart.CartItems.FirstOrDefault(cartItem => cartItem.Id.Equals(cartItemId));
            Cart.CartItems.Remove(cartItem);
            _cartService.RemoveCartItem(cartItem.Id);
        }

        return Cart;
    }

    public Cart AddToCart(Guid itemId)
    {
        _cartService.AddCartItem(itemId, Cart);
        return Cart;
    }
}
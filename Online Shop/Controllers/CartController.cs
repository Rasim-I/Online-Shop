using Microsoft.AspNetCore.Mvc;
using OnlineShopLogic.ItemParameters;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace Online_Shop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }

    public Cart GetTestCart()
    {
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
            Cart cart = new Cart() { Id = Guid.NewGuid(), Price = 342, Items = new List<CartItem>(){cartItem1, cartItem2}};

            return cart;
    }

    
    public Cart MoreQuantity(Cart cart, Guid cartItemId)
    {
        Cart cartToUpdate = cart;
        cartToUpdate.Items.Where(cartItem => cartItem.Id.Equals(cartItemId)).FirstOrDefault().Quantity++;
        return cartToUpdate;

    }
    
    public Cart LessQuantity(Cart cart, Guid cartItemId)
    {
        Cart cartToUpdate = cart;

        CartItem cartItemToChange = cartToUpdate.Items.Where(cartItem => cartItem.Id.Equals(cartItemId)).FirstOrDefault();
        
        if (cartItemToChange.Quantity == 1)
        {
            //cartToUpdate.Items.Remove(cartItemToChange);
            RemoveItem(cartToUpdate, cartItemId, cartItemToChange);
        }
        else
        {
            //cartToUpdate.Items.Where(cartItem => cartItem.Id.Equals(cartItemId)).FirstOrDefault().Quantity--;
            cartItemToChange.Quantity--;
        }
        return cartToUpdate;

    }

    public Cart RemoveItem(Cart cart, Guid cartItemId, CartItem? cartItem)
    {
        if (cartItem != null)
        {
            cart.Items.Remove(cartItem);
        }
        else
        {
            cartItem = cart.Items.Where(cartItem => cartItem.Id.Equals(cartItemId)).FirstOrDefault();
            cart.Items.Remove(cartItem);
        }

        return cart;
    }
    
}
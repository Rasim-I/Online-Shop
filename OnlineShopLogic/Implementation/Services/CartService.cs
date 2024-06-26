﻿using AutoMapper;
using Azure.Core;
using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Services;

public class CartService : ICartService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Cart GetCart(Guid customerId)
    {
        CartEntity cartEntity = _unitOfWork.Carts.GetByCustomer(customerId);
        if (cartEntity != null)
        {
            Cart cart = _mapper.Map<Cart>(cartEntity);
            return cart;
        }
        
        return null; //
    }

    public bool UpdateCart(Cart cartToUpdate)
    {
        try
        {
            //_unitOfWork.Carts.Update(_mapper.Map<CartEntity>(cartToUpdate));
            CartEntity cartEntity = _mapper.Map<CartEntity>(cartToUpdate);
            //cartEntity.Price = 19999;
            
            _unitOfWork.Carts.UpdateDetached(cartEntity);
            _unitOfWork.Save();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
            return false;
        }
    }

    public bool UpdateCartItemQuantity(CartItem cartItem)
    {
        try
        {
            CartItemEntity cartItemEntity = _mapper.Map<CartItemEntity>(cartItem); 
            _unitOfWork.CartItems.UpdateDetached(cartItemEntity);
            _unitOfWork.Save();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool RemoveCartItem(Guid cartItemId)
    {
        try
        {
            CartItemEntity cartItemEntity = _unitOfWork.CartItems.Find(ci => ci.Id.Equals(cartItemId)).FirstOrDefault();
            _unitOfWork.CartItems.Remove(cartItemEntity);
            _unitOfWork.Save();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }


    public bool AddCartItem(Guid itemId, Cart cart)
    {
        try
        {
            Item item = _mapper.Map<Item>(_unitOfWork.Items.Find(i => i.Id.Equals(itemId)).FirstOrDefault());
            CartItem cartItem = new CartItem()
                { Id = Guid.NewGuid(), Item = item, Cart = cart, Quantity = 1 };
            cart.CartItems.Add(cartItem);
            //_unitOfWork.CartItems.Create(_mapper.Map<CartItemEntity>(cartItem)); //Continue
            CartItemEntity cartItemEntity = _mapper.Map<CartItemEntity>(cartItem);
            _unitOfWork.Carts.AddCartItem(cartItemEntity, itemId, cart.Id);
            _unitOfWork.Save(); //problem with Item id. Maybe it needs and actual Item. in that case, move this logic to CartItemRepository and detach Item before adding.
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //return false;
            throw;
        }
    }
    
}



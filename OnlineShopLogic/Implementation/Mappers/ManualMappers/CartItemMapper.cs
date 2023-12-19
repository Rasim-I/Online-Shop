using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers.ManualMappers;

public class CartItemMapper : IMapper<CartItemEntity, CartItem>
{
    //private IMapper<ItemEntity, Item> _itemMapper;
    private IMapper _itemMapper;

    public CartItemMapper(IMapper itemMapper)
    {
        _itemMapper = itemMapper;
    }

    public CartItemEntity ToEntity(CartItem model)
    {
        return new CartItemEntity()
        {
            Id = model.Id,
            CartId = model.CartId,
            Item = _itemMapper.Map<ItemEntity>(model.Item),
            ItemId = model.Item.Id,
            Quantity = model.Quantity
        };
    }

    public CartItem ToModel(CartItemEntity entity)
    {
        return new CartItem()
        {
            Id = entity.Id,
            CartId = entity.CartId,
            Item = _itemMapper.Map<Item>(entity.Item),
            //ItemId = entity.Item.Id,
            Quantity = entity.Quantity
        };
    }
    
    
}
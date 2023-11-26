using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CartItemMapper : IMapper<CartItemEntity, CartItem>
{
    private IMapper<ItemEntity, Item> _itemMapper;

    public CartItemMapper(IMapper<ItemEntity, Item> itemMapper)
    {
        _itemMapper = itemMapper;
    }

    public CartItemEntity ToEntity(CartItem model)
    {
        return new CartItemEntity()
        {
            Id = model.Id,
            CartId = model.CartId,
            Item = _itemMapper.ToEntity(model.Item),
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
            Item = _itemMapper.ToModel(entity.Item),
            //ItemId = entity.Item.Id,
            Quantity = entity.Quantity
        };
    }
    
    
}
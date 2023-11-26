using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class OrderMapper : IMapper<OrderEntity, Order>
{
    private IMapper<CustomerEntity, Customer> _customerMapper;
    private IMapper<ItemEntity, Item> _itemMapper;

    public OrderMapper(IMapper<CustomerEntity, Customer> customerMapper, IMapper<ItemEntity, Item> itemMapper)
    {
        _customerMapper = customerMapper;
        _itemMapper = itemMapper;
    }

    public OrderEntity ToEntity(Order model)
    {
        return new OrderEntity()
        {
            Id = model.Id,
            Customer = _customerMapper.ToEntity(model.Customer),
            OrderDate = model.OrderDate,
            Status = (Status)model.Status,
            Items = new List<CartItemEntity>()

        };
    }

    public Order ToModel(OrderEntity entity)
    {
        return new Order()
        {

        };
    }

    /*
    public CartItemEntity Dict(Dictionary<Item, int> items, Guid cartId)
    {
        List<CartItemEntity> cartItemEntities = new List<CartItemEntity>();
        foreach (KeyValuePair<Item, int> keyValue in items)
        {
            cartItemEntities.Add(new CartItemEntity()
            {
                //Id = keyValue.Key. 
                CartId = cartId, 
                Item = _itemMapper.ToEntity(keyValue.Key),
                ItemId = keyValue.Key.Id,
                Quantity = keyValue.Value,
                Id = 
            });
        }
    }
    */
    
}
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class OrderMapper : IMapper<OrderEntity, Order>
{
    private IMapper<CustomerEntity, Customer> _customerMapper;
    private IMapper<ItemEntity, Item> _itemMapper;
    private IMapper<CartItemEntity, CartItem> _cartItemMapper;

    public OrderMapper(IMapper<CustomerEntity, Customer> customerMapper, IMapper<ItemEntity, Item> itemMapper,
        IMapper<CartItemEntity, CartItem> cartItemMapper)
    {
        _customerMapper = customerMapper;
        _itemMapper = itemMapper;
        _cartItemMapper = cartItemMapper;
    }

    public OrderEntity ToEntity(Order model)
    {
        return new OrderEntity()
        {
            Id = model.Id,
            Customer = _customerMapper.ToEntity(model.Customer),
            OrderDate = model.OrderDate,
            Status = (Status)model.Status,
            Items = new List<CartItemEntity>(model.Items.ConvertAll(i => _cartItemMapper.ToEntity(i)))
        };
    }

    public Order ToModel(OrderEntity entity)
    {
        return new Order()
        {
            Id = entity.Id,
            Customer = _customerMapper.ToModel(entity.Customer),
            OrderDate = entity.OrderDate,
            Status = (Models.Enums.Status)entity.Status,
            Items = new List<CartItem>(entity.Items.ConvertAll(i => _cartItemMapper.ToModel(i)))
        };
    }

}
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class OrderMapper : IMapper<OrderEntity, Order>
{
    private IMapper<CustomerEntity, Customer> _customerMapper;

    public OrderMapper(IMapper<CustomerEntity, Customer> customerMapper)
    {
        _customerMapper = customerMapper;
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
}
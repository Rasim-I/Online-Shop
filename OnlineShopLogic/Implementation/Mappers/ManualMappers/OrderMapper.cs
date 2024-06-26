﻿using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Mappers.ManualMappers;

public class OrderMapper : IMapper<OrderEntity, Order>
{
    private IMapper<CustomerEntity, Customer> _customerMapper;
    private IMapper<CartItemEntity, CartItem> _cartItemMapper;

    public OrderMapper(IMapper<CustomerEntity, Customer> customerMapper, IMapper<CartItemEntity, CartItem> cartItemMapper)
    {
        _customerMapper = customerMapper;
        //_itemMapper = itemMapper;
        _cartItemMapper = cartItemMapper;
    }

    public OrderEntity ToEntity(Order model)
    {
        return new OrderEntity()
        {
            Id = model.Id,
            //Customer = _customerMapper.ToEntity(model.Customer),
            OrderDate = model.OrderDate,
            Status = (Status)model.Status,
            //Items = new List<CartItemEntity>(model.Items.ConvertAll(i => _cartItemMapper.ToEntity(i)))
            //Cart = 
        };
    }

    public Order ToModel(OrderEntity entity)
    {
        return new Order()
        {
            Id = entity.Id,
            //Customer = _customerMapper.ToModel(entity.Customer),
            OrderDate = entity.OrderDate,
            Status = (OnlineShopModels.Models.Enums.Status)entity.Status,
            //Items = new List<CartItem>(entity.Items.ConvertAll(i => _cartItemMapper.ToModel(i)))
        };
    }

}
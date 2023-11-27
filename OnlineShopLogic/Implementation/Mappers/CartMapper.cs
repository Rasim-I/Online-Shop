using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CartMapper : IMapper<CartEntity, Cart>
{
    private IMapper<CartItemEntity, CartItem> _cartItemMapper;
    private IMapper<CustomerEntity, Customer> _customerMapper;

    public CartMapper(IMapper<CartItemEntity, CartItem> cartItemMapper, IMapper<CustomerEntity, Customer> customerMapper)
    {
        _cartItemMapper = cartItemMapper;
        _customerMapper = customerMapper;
    }
    
    public CartEntity ToEntity(Cart model)
    {
        return new CartEntity()
        {
            Id = model.Id,
            Customer = _customerMapper.ToEntity(model.Customer),
            Price = model.Price,
            Items = new List<CartItemEntity>(model.Items.ConvertAll(i => _cartItemMapper.ToEntity(i)))
        };
    }

    public Cart ToModel(CartEntity entity)
    {
        return new Cart()
        {
            Id = entity.Id,
            Customer = _customerMapper.ToModel(entity.Customer),
            Price = entity.Price,
            Items = new List<CartItem>(entity.Items.ConvertAll(i => _cartItemMapper.ToModel(i)))
        };
    }
    
}
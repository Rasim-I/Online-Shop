using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<CartEntity, Cart>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));

        CreateMap<Cart, CartEntity>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));

    }
}
using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CartItemMappingProfile : Profile
{
    public CartItemMappingProfile()
    {
        CreateMap<CartItemEntity, CartItem>()
            //.ForMember(dest => dest.CartId,
            //    opt => opt.MapFrom(src => src.CartId))
            //.ForMember(dest => dest.ItemId,
             //   opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Item,
                opt => opt.MapFrom(src => src.Item));

        CreateMap<CartItem, CartItemEntity>()
            //.ForMember(dest => dest.CartId,
            //    opt => opt.MapFrom(src => src.CartId))
            //.ForMember(dest => dest.ItemId,
           //     opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.Item,
                opt => opt.MapFrom(src => src.Item));

    }
    
}
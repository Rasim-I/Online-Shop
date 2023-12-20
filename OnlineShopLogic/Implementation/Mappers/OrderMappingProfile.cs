using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Implementation.Mappers;

public class OrderMappingProfile : Profile
{

    public OrderMappingProfile()
    {
        CreateMap<OrderEntity, Order>()
            .ForMember(dest => dest.Customer,
                opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Items,
                opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => (Status)src.Status));


        CreateMap<Order, OrderEntity>()
            .ForMember(dest => dest.Customer,
                opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Items,
                opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => (OnlineShopDAL.Entities.Enums.Status)src.Status));



    }
    
    
}
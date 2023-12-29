using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopModels.Models;
using OnlineShopModels.Models.Enums;

namespace OnlineShopLogic.Implementation.Mappers;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<ReviewEntity, Review>()
            .ForMember(dest => dest.Customer,
                opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Item,
                opt => opt.MapFrom(src => src.Item))
            .ForMember(dest => dest.Stars,
                opt => opt.MapFrom(src => (Stars)src.Stars))
            .ForMember(dest => dest.Photos,
                opt => opt.MapFrom(src => src.Photos));

        CreateMap<Review, ReviewEntity>()
            .ForMember(dest => dest.Customer, 
                opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Item, 
                opt => opt.MapFrom(src => src.Item))
            .ForMember(dest => dest.Stars, 
                opt => opt.MapFrom(src => (OnlineShopDAL.Entities.Enums.Stars)src.Stars))
            .ForMember(dest => dest.Photos, 
                opt => opt.MapFrom(src => src.Photos));
    }
    
    
}
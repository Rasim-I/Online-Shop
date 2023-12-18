using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class PhotoMappingProfile : Profile
{
    public PhotoMappingProfile()
    {
        CreateMap<PhotoEntity, Photo>()
            .ForMember(dest=> dest.ItemId,
                opt=>opt.MapFrom(src=>src.ItemEntityId))
            .ForMember(dest=>dest.ReviewId,
                opt=>opt.MapFrom(src=>src.ReviewEntityId));

        CreateMap<Photo, PhotoEntity>()
            .ForMember(dest=>dest.ItemEntityId,
                opt=>opt.MapFrom(src=>src.ItemId))
            .ForMember(dest=>dest.ReviewEntityId,
                opt=>opt.MapFrom(src=>src.ReviewId));
    }
    
    
}
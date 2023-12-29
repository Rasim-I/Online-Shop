using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopModels.Models;
using OnlineShopModels.Models.Enums;

namespace OnlineShopLogic.Implementation.Mappers;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryEntity, Category>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src =>(CategoryName)src.Name));

        CreateMap<Category, CategoryEntity>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src =>(OnlineShopDAL.Entities.Enums.CategoryName)src.Name));
    }
    
}
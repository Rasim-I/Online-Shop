using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Categories;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.Categories;

namespace OnlineShopLogic.Implementation.Mappers;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryEntity, Category>().IncludeAllDerived();

        CreateMap<Category, CategoryEntity>().IncludeAllDerived();

        CreateMap<CategoryItemElectronicsEntity, CategoryItemElectronics>().IncludeBase<CategoryEntity, Category>();
        CreateMap<CategoryItemDecorationsEntity, CategoryItemDecorations>().IncludeBase<CategoryEntity, Category>();
        CreateMap<CategoryItemClothesEntity, CategoryItemClothes>().IncludeBase<CategoryEntity, Category>();
        CreateMap<CategoryItemSportEntity, CategoryItemSport>().IncludeBase<CategoryEntity, Category>();
    }
    
    
}

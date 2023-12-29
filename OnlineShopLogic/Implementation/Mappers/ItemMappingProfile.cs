using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.ItemTypes;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopLogic.Implementation.Mappers;

public class ItemMappingProfile : Profile
{
    //private IMapper<CategoryEntity, Category> _categoryMapper;
    //private IMapper<PhotoEntity, Photo> _photoMapper;
    
    public ItemMappingProfile()//IMapper<CategoryEntity, Category> categoryMapper, IMapper<PhotoEntity, Photo> photoMapper)
    {
        //_categoryMapper = categoryMapper;
        //_photoMapper = photoMapper;


        CreateMap<ItemEntity, Item>()
            //.PreserveReferences()
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Photos,
                opt => opt.MapFrom(src => src.Photos));

        CreateMap<Item, ItemEntity>()
            //.PreserveReferences()
            .ForMember(dest => dest.Category,
                opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Photos,
                opt => opt.MapFrom(src => src.Photos));


        
        CreateMap<ItemElectronicsEntity, ItemElectronics>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemDecorationsEntity, ItemDecorations>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemClothesEntity, ItemClothes>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemSportEntity, ItemSport>().IncludeBase<ItemEntity, Item>();
    }
}
using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.ItemTypes;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.ItemTypes;

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
            .IncludeAllDerived();
            //.ForMember(
            //    dest => dest.Category,
            //    opt => opt.MapFrom(src => _categoryMapper.ToModel(src.Category)));
            //Make the same for Photos
        CreateMap<Item, ItemEntity>().IncludeAllDerived();
            //.ForMember(
            //    dest =>dest.Category,
            //    opt => opt.MapFrom(src =>_categoryMapper.ToEntity(src.Category)));
            //Make the same for Photos

        
        CreateMap<ItemElectronicsEntity, ItemElectronics>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemDecorationsEntity, ItemDecorations>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemClothesEntity, ItemClothes>().IncludeBase<ItemEntity, Item>();
        CreateMap<ItemSportEntity, ItemSport>().IncludeBase<ItemEntity, Item>();
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.Categories;

namespace OnlineShopLogic.Implementation.Mappers;

public class CategoryMapper : IMapper<CategoryEntity, Category> 
    
{
    //private IMapper<CategoryEntity, Category> _categoryMapper;
    private IMapper<ItemEntity, Item> _itemMapper;

    public CategoryMapper(IMapper<ItemEntity, Item> itemMapper)
    {
        //_categoryMapper = categoryMapper;
        _itemMapper = itemMapper;
    }


    
    
    public TCategoryEntity? ToEntity<TCategoryEntity>(Category model)
        where TCategoryEntity : CategoryEntity, new()
    {
        
        if (model is CategoryItemElectronics electronics)
        {
             return ToEntity(electronics) as TCategoryEntity;
        }
        else if (model is CategoryItemClothes clothes)
        {
             return ToEntity(clothes) as TCategoryEntity;
        }
        else if (model is CategoryItemDecorations decorations)
        {
             return ToEntity(decorations) as TCategoryEntity;
        }
        else if (model is CategoryItemSport sport)
        {
             return ToEntity(sport) as TCategoryEntity;
        }

        
        return new CategoryEntity()
        {
            Id = model.Id,
            //Name = (CategoryNames)model.Name,
            RootCategory = model.RootCategory,
            IsRoot = model.IsRoot,
            //Item = _itemMapper.ToEntity(model.Item)
            //SubCategories = new List<CategoryEntity>(model.SubCategories.ConvertAll(ToEntity))
                //model.SubCategories?.Select(c => _categoryMapper.ToEntity(c)).ToList() ?? new List<CategoryEntity>()
        } as TCategoryEntity;
    }

    public Category ToModel(CategoryEntity entity)
    {
        return new Category()
        {
            Id = entity.Id,
            //Name = (Models.Enums.CategoryNames)entity.Name,
            RootCategory = entity.RootCategory,
            IsRoot = entity.IsRoot,
            //Item = _itemMapper.ToModel(entity.Item)
            //SubCategories = new List<Category>(entity.SubCategories.ConvertAll(ToModel))
        };
    }
    
    
    
    public CategoryItemElectronics ToEntity(CategoryItemElectronics electronics)
    {
        return new CategoryItemElectronics()
        {
            Id = electronics.Id,
            RootCategory = electronics.RootCategory,
            IsRoot = electronics.IsRoot,
            CpuModel = electronics.CpuModel,
            MemoryCapacity = electronics.MemoryCapacity
        };
    }

    public CategoryItemClothes ToEntity(CategoryItemClothes clothes)
    {
        return new CategoryItemClothes()
        {
            Id = clothes.Id,
            RootCategory = clothes.RootCategory,
            IsRoot = clothes.IsRoot,
            Size = clothes.Size,
            Gender = clothes.Gender
        };
    }

    public CategoryItemDecorations ToEntity(CategoryItemDecorations decorations)
    {
        return new CategoryItemDecorations()
        {
            Id = decorations.Id,
            RootCategory = decorations.RootCategory,
            IsRoot = decorations.IsRoot,
            Color = decorations.Color,
            Material = decorations.Material
        };
    }

    public CategoryItemSport ToEntity(CategoryItemSport sport)
    {
        return new CategoryItemSport()
        {
            Id = sport.Id,
            RootCategory = sport.RootCategory,
            IsRoot = sport.IsRoot,
            Category = sport.Category
        };
    }
    
    
}
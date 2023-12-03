using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CategoryMapper : IMapper<CategoryEntity, Category>
{
    //private IMapper<CategoryEntity, Category> _categoryMapper;

    public CategoryMapper()
    {
        //_categoryMapper = categoryMapper;
    }


    public CategoryEntity ToEntity(Category model)
    {
        return new CategoryEntity()
        {
            Id = model.Id,
            Name = (CategoryNames)model.Name,
            RootCategory = model.RootCategory,
            IsRoot = model.IsRoot
            //SubCategories = new List<CategoryEntity>(model.SubCategories.ConvertAll(ToEntity))
                //model.SubCategories?.Select(c => _categoryMapper.ToEntity(c)).ToList() ?? new List<CategoryEntity>()
        };
    }

    public Category ToModel(CategoryEntity entity)
    {
        return new Category()
        {
            Id = entity.Id,
            Name = (Models.Enums.CategoryNames)entity.Name,
            RootCategory = entity.RootCategory,
            IsRoot = entity.IsRoot
            //SubCategories = new List<Category>(entity.SubCategories.ConvertAll(ToModel))
        };
    }
    
}
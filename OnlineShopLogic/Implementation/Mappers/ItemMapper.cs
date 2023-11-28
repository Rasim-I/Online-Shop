using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

//TODO Break circular dependencies by adding interface for each concrete mapper

public class ItemMapper : IMapper<ItemEntity, Item>
{
    private IMapper<PhotoEntity, Photo> _photoMapper;
    private IMapper<CategoryEntity, Category> _categoryMapper;

    public ItemMapper(IMapper<PhotoEntity, Photo> photoMapper, IMapper<CategoryEntity, Category> categoryMapper)
    {
        _photoMapper = photoMapper;
        _categoryMapper = categoryMapper;
    }

    public ItemEntity ToEntity(Item model)
    {
        return new ItemEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Quantity = model.Quantity,
            Photos = new List<PhotoEntity>(model.Photos.ConvertAll(p => _photoMapper.ToEntity(p))),
            Category = _categoryMapper.ToEntity(model.Category)
        };
    }

    public Item ToModel(ItemEntity entity)
    {
        return new Item()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Quantity = entity.Quantity,
            Photos = new List<Photo>(entity.Photos.ConvertAll(p => _photoMapper.ToModel(p))),
            Category = _categoryMapper.ToModel(entity.Category)
        };
    }
    
}
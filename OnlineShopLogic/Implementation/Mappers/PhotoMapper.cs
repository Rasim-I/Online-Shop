using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class PhotoMapper : IMapper<PhotoEntity, Photo>
{
    private IMapper<ItemEntity, Item> _itemMapper;
    private IMapper<ReviewEntity, Review> _reviewMapper;

    public PhotoMapper(IMapper<ItemEntity, Item> itemMapper, IMapper<ReviewEntity, Review> reviewMapper)
    {
        _itemMapper = itemMapper;
        _reviewMapper = reviewMapper;
    }
    
    public PhotoEntity ToEntity(Photo model)
    {
        return new PhotoEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Link = model.Link,
            ItemEntityId = model.Item?.Id,
            ReviewEntityId = model.Review?.Id,
            Item = model.Item == null? null : _itemMapper.ToEntity(model.Item),
            Review = model.Review == null? null : _reviewMapper.ToEntity(model.Review)
        };
    }

    public Photo ToModel(PhotoEntity entity)
    {
        return new Photo()
        {
            Id = entity.Id,
            Name = entity.Name,
            Link = entity.Link,
            Item = _itemMapper.ToModel(entity.Item),
            Review = _reviewMapper.ToModel(entity.Review)
        };
    }
    
}
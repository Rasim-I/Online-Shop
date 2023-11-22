using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class PhotoMapper : IMapper<PhotoEntity, Photo>
{

    public PhotoEntity ToEntity(Photo model)
    {
        return new PhotoEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Link = model.Link,
            //ItemEntityId = model.Item?.Id,
            //ReviewEntityId = model.Review?.Id
        };
    }

    public Photo ToModel(PhotoEntity entity)
    {
        return new Photo()
        {
            Id = entity.Id,
            Name = entity.Name,
            Link = entity.Link,
        };
    }
    
}
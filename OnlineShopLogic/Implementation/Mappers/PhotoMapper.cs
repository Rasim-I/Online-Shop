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
            ItemEntityId = model.ItemId,
            ReviewEntityId = model.ReviewId,
            IsMain = model.IsMain
            //Item = MapItemEntity(model.Item), //model.Item == null? null : _itemMapper.ToEntity(model.Item),
            //Review = MapReviewEntity(model.Review) //model.Review == null? null : _reviewMapper.ToEntity(model.Review)
        };
    }

    public Photo ToModel(PhotoEntity entity)
    {
        return new Photo()
        {
            Id = entity.Id,
            Name = entity.Name,
            Link = entity.Link,
            ItemId = entity.ItemEntityId,
            ReviewId = entity.ReviewEntityId,
            IsMain = entity.IsMain
            //Item = MapItem(entity.Item), //_itemMapper.ToModel(entity.Item),
            //Review = MapReview(entity.Review) //_reviewMapper.ToModel(entity.Review)
        };
    }

    /*
    private Item MapItem(ItemEntity? itemEntity)
    {
        return itemEntity == null ? null : _itemMapper.ToModel(itemEntity);
    }
    
    private ItemEntity MapItemEntity(Item? item)
    {
        return item == null ? null : _itemMapper.ToEntity(item);
    }

    private Review MapReview(ReviewEntity? reviewEntity)
    {
        return reviewEntity == null ? null : _reviewMapper.ToModel(reviewEntity);
    }

    private ReviewEntity MapReviewEntity(Review? review)
    {
        return review == null ? null : _reviewMapper.ToEntity(review);
    }
    */
}
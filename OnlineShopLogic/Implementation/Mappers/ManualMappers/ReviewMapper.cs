﻿using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Mappers.ManualMappers;

public class ReviewMapper : IMapper<ReviewEntity, Review>
{
    private IMapper<CustomerEntity, Customer> _customerMapper;
    //private IMapper<ItemEntity, Item> _itemMapper;
    private IMapper _itemMapper;
    private IMapper<PhotoEntity, Photo> _photoMapper;

    public ReviewMapper(IMapper<CustomerEntity, Customer> customerMapper, 
        IMapper itemMapper, IMapper<PhotoEntity, Photo> photoMapper)
    {
        _customerMapper = customerMapper;
        _itemMapper = itemMapper;
        _photoMapper = photoMapper;
    }

    public ReviewEntity ToEntity(Review model)
    {
        return new ReviewEntity()
        {
            Id = model.Id,
            ReviewDate = model.ReviewDate,
            Stars = (Stars)model.Stars,
            Text = model.Text,
            Item = _itemMapper.Map<ItemEntity>(model.Item),
            Customer = _customerMapper.ToEntity(model.Customer),
            Photos = new List<PhotoEntity>(model.Photos.ConvertAll(p => _photoMapper.ToEntity(p)))
        };
    }

    public Review ToModel(ReviewEntity entity)
    {
        return new Review()
        {
            Id = entity.Id,
            ReviewDate = entity.ReviewDate,
            Stars = (OnlineShopModels.Models.Enums.Stars)entity.Stars,
            Text = entity.Text,
            Item = _itemMapper.Map<Item>(entity.Item),
            Customer = _customerMapper.ToModel(entity.Customer),
            Photos = new List<Photo>(entity.Photos.ConvertAll(p => _photoMapper.ToModel(p)))
        };
    }
    
    
}
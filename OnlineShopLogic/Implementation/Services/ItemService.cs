using AutoMapper;
using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Utility;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.Mappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Services;

public class ItemService : IItemService
{
    private IUnitOfWork _unitOfWork;
    //private IMapper<ItemEntity, Item> _itemMapper;
    private IMapper _mapper;
    
    public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        //_itemMapper = itemMapper;
        _mapper = mapper;
    }

    public bool FillDatabase()
    {
        try
        {
            InitData initData = new InitData(_unitOfWork);
            initData.FillDatabase();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public List<Item> GetItems()
    {
        List<Item> itemsResult = new List<Item>();

        foreach (var item in _unitOfWork.Items.GetAll_IncludeAll())
        {
            itemsResult.Add(_mapper.Map<Item>(item));
            itemsResult.Add(_mapper.Map<Item>(item));
        }

        return itemsResult;
    }

    public Item GetItem(Guid itemId)
    {
        ItemEntity? itemEntity = _unitOfWork.Items.GetById(itemId);

        if (itemEntity == null)
        {
            throw new NullReferenceException("There is no item with that Id");
        }

        Item item = _mapper.Map<Item>(itemEntity);
        return item;
    }

}

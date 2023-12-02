using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Utility;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Implementation.Mappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Services;

public class ItemService
{
    private IUnitOfWork _unitOfWork;
    private IMapper<ItemEntity, Item> _itemMapper;
    
    public ItemService(IUnitOfWork unitOfWork, IMapper<ItemEntity, Item> itemMapper)
    {
        _unitOfWork = unitOfWork;
        _itemMapper = itemMapper;
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
            itemsResult.Add(_itemMapper.ToModel(item));
            itemsResult.Add(_itemMapper.ToModel(item));
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

        Item item = _itemMapper.ToModel(itemEntity);
        return item;
    }

}

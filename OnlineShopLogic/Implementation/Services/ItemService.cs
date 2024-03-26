using AutoMapper;
using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Utility;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.Mappers;
using OnlineShopModels.Models;
using System.Linq;
using OnlineShopLogic.Implementation.FilterChain;
using OnlineShopLogic.ItemParameters;
using OnlineShopModels.Models.ItemTypes;

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
            //itemsResult.Add(_mapper.Map<Item>(item));
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

    public Category? GetCategoryByName(string categoryName)
    {
        CategoryName categoryNameEnum;
        if (Enum.TryParse(categoryName, out categoryNameEnum))
        {
            Category? category = _mapper
                .Map<Category>(_unitOfWork.Categories.GetCategoryByName(categoryNameEnum)
                    .FirstOrDefault()); //TODO optimization needed
            return category;
        }
        else
            return null;
    }

    public Category? GetCategory(CategoryName categoryName)
    {
        Category? category =
            _mapper.Map<Category>(_unitOfWork.Categories.Find(c => c.Name == categoryName).FirstOrDefault());
        return category;
    }


    public List<Item>
        GetItemsByCategory(string categoryName) //TODO optimization needed. Maybe merge with GetItemsByCategoryName()
    {
        List<Item> items = new List<Item>();
        var category = GetCategoryByName(categoryName);
        if (category != null)
        {
            //return _unitOfWork.Items.GetByCategory(category.Id).ToList().ConvertAll(_mapper.Map<Item>);

            foreach (var item in _unitOfWork.Items.GetByCategory(category.Id).ToList().ConvertAll(_mapper.Map<Item>))
            {
                items.Add(item);
                items.Add(item);
            }

            return items;
        }
        else
            return new List<Item>(); //consider handling wrong category name
    }

    public List<Item> GetItemsByBrand(string brandName)
    {
        List<Item> items = _unitOfWork.Items
            .GetAll().Where(i => i.Brand.Equals(brandName)).ToList()
            .ConvertAll(_mapper.Map<ItemEntity, Item>);
        return items;
    }

    public List<ItemElectronics> GetElectronicsByCpuModel(string cpuModel)
    {
        try
        {
            Guid categoryId = _unitOfWork.Categories.Find(c => c.Name == CategoryName.Electronics).FirstOrDefault().Id;
            List<ItemElectronics> itemsToFilter = _unitOfWork.Items.GetByCategory(categoryId).ToList()
                .ConvertAll(_mapper.Map<ItemEntity, ItemElectronics>);

            return itemsToFilter.Where(i => i.CpuModel.Equals(cpuModel)).ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public List<ItemElectronics> GetElectronicsByMemoryCapacity(string memoryCapacity)
    {
        try
        {
            Guid categoryId = _unitOfWork.Categories.Find(c => c.Name == CategoryName.Electronics).FirstOrDefault().Id;
            List<ItemElectronics> itemsToFilter = _unitOfWork.Items.GetByCategory(categoryId).ToList()
                .ConvertAll(_mapper.Map<ItemEntity, ItemElectronics>);
            return itemsToFilter.Where(i => i.MemoryCapacity.Equals(memoryCapacity)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<ItemElectronics> MapToItemElectronics(List<Item> items)
    {
        List<ItemElectronics> mappedItems = new List<ItemElectronics>();
        foreach (var item in items)
        {
            if (item is ItemElectronics itemElectronics)
            {
                mappedItems.Add(itemElectronics);
            }
        }

        return mappedItems;
    }

    public List<ItemSport> MapToItemSport(List<Item> items)
    {
        List<ItemSport> mappedItems = new List<ItemSport>();
        foreach (var item in items)
        {
            if (item is ItemSport itemSport)
            {
                mappedItems.Add(itemSport);
            }
        }

        return mappedItems;
    }

    public List<ItemClothes> MapToItemClothes(List<Item> items)
    {
        List<ItemClothes> mappedItems = new List<ItemClothes>();
        foreach (var item in items)
        {
            if (item is ItemClothes itemClothes)
            {
                mappedItems.Add(itemClothes);
            }
        }

        return mappedItems;
    }

    public List<ItemDecorations> MapToItemDecorations(List<Item> items)
    {
        List<ItemDecorations> mappedItems = new List<ItemDecorations>();
        foreach (var item in items)
        {
            if (item is ItemDecorations itemDecorations)
            {
                mappedItems.Add(itemDecorations);
            }
        }

        return mappedItems;
    }


    public List<Item> GetItemsByCategoryName(OnlineShopModels.Models.Enums.CategoryName category)
    {
        try
        {
            CategoryName
                categoryEntity =
                    (CategoryName)category; //(CategoryName)Enum.Parse(typeof(CategoryEntity), category.ToString());

            Guid categoryId = _unitOfWork.Categories.Find(c => c.Name == categoryEntity).FirstOrDefault().Id;
            return _unitOfWork.Items.GetByCategory(categoryId).ToList().ConvertAll(_mapper.Map<ItemEntity, Item>);
        }
        catch (Exception e)
        {
            Console.WriteLine("Problem with database or category does not exist");
            return new List<Item>();
        }
    }

    public List<Item> GetItemsMock()
    {
        List<Item> items = new List<Item>();
        Category category = new Category()
            { Id = Guid.NewGuid(), Name = OnlineShopModels.Models.Enums.CategoryName.Electronics, IsRoot = true };
        items.Add(new ItemElectronics()
        {
            Brand = ItemElectronicsParameters.HPBrand, Category = category,
            CpuModel = ItemElectronicsParameters.AMDCpuModel, Description = "description", Id = Guid.NewGuid(),
            MemoryCapacity = ItemElectronicsParameters.Memory64, Name = "Laptop test model", Price = 222, Quantity = 23
        });

        items.Add(new ItemElectronics()
        {
            Brand = ItemElectronicsParameters.AsusBrand, Category = category,
            CpuModel = ItemElectronicsParameters.IntelCpuModel, Description = "other description", Id = Guid.NewGuid(),
            MemoryCapacity = ItemElectronicsParameters.Memory512, Name = "Laptop test model 2", Price = 212,
            Quantity = 23
        });
        return items;


        Category categoryClothes = new Category()
            { Id = Guid.NewGuid(), IsRoot = true, Name = OnlineShopModels.Models.Enums.CategoryName.Clothes };
        List<Item> itemClothes = new List<Item>();
        itemClothes.Add(new ItemClothes()
        {
            Brand = ItemClothesParameters.DiadoraBrand, Category = categoryClothes,
            Gender = ItemClothesParameters.FemaleGender, Description = "something", Id = Guid.NewGuid(),
            Size = ItemClothesParameters.SizeM, Name = "t-short", Price = 12, Quantity = 23
        });

        itemClothes.Add(new ItemClothes()
        {
            Brand = ItemClothesParameters.CropBrand, Category = categoryClothes,
            Gender = ItemClothesParameters.MaleGender, Description = "something 2", Id = Guid.NewGuid(),
            Size = ItemClothesParameters.SizeM, Name = "pants", Price = 12, Quantity = 23
        });
        return itemClothes;
    }


    public List<Item> SearchByKeywords(List<string> keywords)
    {
        List<Item> allItems = GetItems();
        List<Item> filteredItems = new List<Item>();
        
        foreach (var item in allItems)
        {
            List<string> itemParameters = new List<string>()
                { item.Name.ToLower(), item.Category.Name.ToString().ToLower(), item.Description.ToLower(), item.Brand.ToLower() };
            string concatenatedItemParameters = string.Join(" ", itemParameters);

            bool allContained = keywords.All(word => concatenatedItemParameters.Contains(word.ToLower()));
            if (allContained)
                filteredItems.Add(item);
        }

        return filteredItems;
    }
}
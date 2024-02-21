using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopDAL;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain;
using OnlineShopLogic.Implementation.FilterChain.ItemClothesHandlers;
using OnlineShopLogic.Implementation.FilterChain.ItemElectronicsHandlers;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopLogic.Implementation.Mappers;
using OnlineShopLogic.Implementation.Services;
using OnlineShopLogic.ItemParameters;
using OnlineShopModels.Models;

namespace OnlineShopLogicTests;

public class Tests
{
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new OnlineShopContext(new DbContextOptions<OnlineShopContext>()));

        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ItemMappingProfile>();
        });
        IItemService itemService = new ItemService(unitOfWork, new Mapper(mapperConfiguration));

        ItemElectronicsSearchModel item = new ItemElectronicsSearchModel()
        {
            Brands = new List<string>(){ ItemElectronicsParameters.HPBrand, ItemElectronicsParameters.AsusBrand}, 
            MinPrice = 3, MaxPrice = 10000, Name = "Something", 
            CpuModels = new List<string>(){ItemElectronicsParameters.AMDCpuModel, ItemElectronicsParameters.IntelCpuModel},
            MemoryCapacities = new List<string>(){ ItemElectronicsParameters.Memory64, ItemElectronicsParameters.Memory512 }
        };
        //BrandHandler br = new BrandHandler();
        BrandHandler br = new BrandHandler();
        CpuModelHandler cpu = new CpuModelHandler();
        MemoryCapacityHandler mem = new MemoryCapacityHandler();
        PriceHandler price = new PriceHandler();

        br.Successor = cpu;
        cpu.Successor = mem;
        mem.Successor = price;

        foreach (var i in br.HandleRequest(itemService, item, itemService.GetItemsMock()))
        {
            Console.WriteLine(i.Name);   
        }

    }

    [Test]
    public void TestItemClothesHandlers()
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new OnlineShopContext(new DbContextOptions<OnlineShopContext>()));

        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ItemMappingProfile>();
        });
        IItemService itemService = new ItemService(unitOfWork, new Mapper(mapperConfiguration));

        ItemClothesSearchModel item = new ItemClothesSearchModel()
        {
            Brands = new List<string>(){ ItemClothesParameters.DiadoraBrand}, 
            MinPrice = 0, MaxPrice = 11, Name = "Something", 
            Gender = ItemClothesParameters.FemaleGender,
            Sizes = new List<string>(){ ItemClothesParameters.SizeS, ItemClothesParameters.SizeM }
        };
        //BrandHandler br = new BrandHandler();
        BrandHandler br = new BrandHandler();
        SizeHandler size = new SizeHandler();
        GenderHandler gen = new GenderHandler();
        PriceHandler price = new PriceHandler();

        br.Successor = size;
        size.Successor = gen;
        gen.Successor = price;

        foreach (var i in br.HandleRequest(itemService, item, itemService.GetItemsMock()))
        {
            Console.WriteLine(i.Name);   
        }

    }
    
}
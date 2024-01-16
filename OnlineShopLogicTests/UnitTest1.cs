using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopDAL;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain;
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
            MinPrice = 3, MaxPrice = 10, Name = "Something", 
            CpuModels = new List<string>(){ItemElectronicsParameters.AMDCpuModel, ItemElectronicsParameters.IntelCpuModel},
            MemoryCapacities = new List<string>(){ ItemElectronicsParameters.Memory64, ItemElectronicsParameters.Memory512 }
        };
        //BrandHandler br = new BrandHandler();
        BrandHandler br = new BrandHandler();
        CpuModelHandler cpu = new CpuModelHandler();
        MemoryCapacityHandler mem = new MemoryCapacityHandler();

        br.Successor = cpu;
        cpu.Successor = mem;

        foreach (var i in br.HandleRequest(itemService, item, itemService.GetItemsMock()))
        {
            Console.WriteLine(i.Name);   
        }

    }
}
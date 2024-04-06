using System.Text;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.WebMappers;
using OnlineShopDAL.Entities.Enums.ItemParameters.ItemSport;
using OnlineShopLogic.Utility;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.FilterChain;
using OnlineShopLogic.Implementation.FilterChain.ItemClothesHandlers;
using OnlineShopLogic.Implementation.FilterChain.ItemDecorationsHandlers;
using OnlineShopLogic.Implementation.FilterChain.ItemElectronicsHandlers;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopLogic.Implementation.FilterChain.ItemSportHandlers;
using OnlineShopLogic.Implementation.Services;
using OnlineShopLogic.ItemParameters;
using OnlineShopModels.Models;
using OnlineShopModels.Models.Enums;
using OnlineShopModels.Models.ItemTypes;
using Activity = System.Diagnostics.Activity;

namespace Online_Shop.Controllers;

[Controller]
[Route("[controller]")]
public class ItemController : Controller
{
    private readonly ILogger<ItemController> _logger;
    private IItemService _itemService;
    private ItemWebModelMapper _itemWebModelMapper;

    public ItemController(ILogger<ItemController> logger, IItemService itemService,
        ItemWebModelMapper itemWebModelMapper)
    {
        _logger = logger;
        _itemService = itemService;
        _itemWebModelMapper = itemWebModelMapper;
    }

    [HttpGet("/fillDatabase")]
    public bool FillDatabase()
    {
        return _itemService.FillDatabase();
    }

    [HttpGet("/addCartItems")]
    public bool AddCartItems()
    {
        return _itemService.AddCartItems();
    }
    
    /*
    [HttpGet("{category}")]
    public IActionResult ItemCategory(string category)
    {
       
        ItemWebModelMapper itemWebModelMapper = new ItemWebModelMapper();
        List<ItemWebModel> items =
            _itemService.GetItemsByCategory(category)
                .ConvertAll(model => itemWebModelMapper.ToWebModel(model)); //TODO Needs optimization
        //_itemService.GetItems().ConvertAll(model => itemWebModelMapper.ToWebModel(model));

        Category? categoryModel = _itemService.GetCategoryByName(category);
        if (categoryModel != null)
        {
            ViewBag.Category = categoryModel;
        }
        else
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View("Error", errorViewModel);
        }

        return View(items);
    }
*/
    
    public IActionResult ItemPage([FromQuery] string itemId)
    {
        Item item = _itemService.GetItem(Guid.Parse(itemId));
        return View(item);
    }

    
    /*
    [HttpPost]
    public IActionResult FilterItems([FromForm] ItemSearchModel itemSearchModel, [FromForm]Category category)
    {
        switch (category.Name)
        {
            case CategoryName.Electronics:
            {
                BrandHandler brand = new BrandHandler();
                CpuModelHandler cpu = new CpuModelHandler();
                MemoryCapacityHandler memory = new MemoryCapacityHandler();
                PriceHandler price = new PriceHandler();
                
                brand.Successor = cpu;
                cpu.Successor = memory;
                memory.Successor = price;
                
                List<Item> itemElectronics = _itemService.GetItemsByCategoryName(category.Name);
                List<Item> filteredItems = brand.HandleRequest(_itemService, itemSearchModel, itemElectronics);
                ViewBag.Category = category;
                return View("ItemCategory", filteredItems.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
            }
            case CategoryName.Clothes:
            {
                BrandHandler brand = new BrandHandler();
                GenderHandler gender = new GenderHandler();
                SizeHandler size = new SizeHandler();
                PriceHandler price = new PriceHandler();

                brand.Successor = gender;
                gender.Successor = size;
                size.Successor = price;
                List<Item> itemClothes = _itemService.GetItemsByCategoryName(category.Name);
                List<Item> filteredItems = brand.HandleRequest(_itemService, itemSearchModel, itemClothes);
                ViewBag.Category = category;
                return View("ItemCategory", filteredItems.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
            }
            case CategoryName.Sport:
            {
                BrandHandler brand = new BrandHandler();
                ActivityHandler activity = new ActivityHandler();
                PriceHandler price = new PriceHandler();

                brand.Successor = activity;
                activity.Successor = price;
                List<Item> itemSport = _itemService.GetItemsByCategoryName(category.Name);
                List<Item> filteredItems = brand.HandleRequest(_itemService, itemSearchModel, itemSport);
                ViewBag.Category = category;
                return View("ItemCategory", filteredItems.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
            }
            case CategoryName.Decorations:
            {
                BrandHandler brand = new BrandHandler();
                ColorHandler color = new ColorHandler();
                MaterialHandler material = new MaterialHandler();
                PriceHandler price = new PriceHandler();
                
                brand.Successor = color;
                color.Successor = material;
                material.Successor = price;
                List<Item> itemDecorations = _itemService.GetItemsByCategoryName(category.Name);
                List<Item> filteredItems = brand.HandleRequest(_itemService, itemSearchModel, itemDecorations);
                ViewBag.Category = category;
                return View("ItemCategory", filteredItems.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
            }
            default:
                return View("ItemCategory");
               
            //case CategoryName.Clothes:
            //    return "Its clothes. (From switch statement)";
        }
        
        
    }
    */


    [HttpGet("/{category}")]
    public IActionResult FilterItems(string category, List<string> brands = null, 
        List<string> cpuModels = null, List<string> memoryCapacities = null, 
        List<string> activities = null, 
        string gender = "", List<string> sizes = null, 
        List<string> materials = null, List<string> colors = null,
        int minPrice = 0, int maxPrice = 0)
    {
        try
        {
            Category? categoryModel = _itemService.GetCategoryByName(category);
            
            BrandHandler brandHandler = new BrandHandler();
            PriceHandler priceHandler = new PriceHandler();
            
            switch (categoryModel.Name)
            {
                case CategoryName.Electronics:
                    ItemSearchModel electronicsSearchModel = new ItemElectronicsSearchModel()
                    {
                        Brands = brands, 
                        CpuModels = cpuModels, MemoryCapacities = memoryCapacities,
                        MinPrice = minPrice, MaxPrice = maxPrice
                    };
                    CpuModelHandler cpuHandler = new CpuModelHandler();
                    MemoryCapacityHandler memoryHandler = new MemoryCapacityHandler();

                    brandHandler.Successor = cpuHandler;
                    cpuHandler.Successor = memoryHandler;
                    memoryHandler.Successor = priceHandler;

                    List<Item> itemsElectronics = _itemService.GetItemsByCategoryName(categoryModel.Name);
                    List<Item> filteredElectronicsItems = brandHandler.HandleRequest(_itemService, electronicsSearchModel, itemsElectronics);
                    ViewBag.Category = categoryModel;
                    ViewBag.ElectronicsSearchModel = electronicsSearchModel;
                    return View("ItemCategory",
                        filteredElectronicsItems);//.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
                
                case CategoryName.Sport:
                {
                    ItemSearchModel sportSearchModel = new ItemSportSearchModel()
                    {
                        Brands = brands, 
                        Activities = activities,
                        MinPrice = minPrice, MaxPrice = maxPrice
                    };
                    ActivityHandler activityHandler = new ActivityHandler();

                    brandHandler.Successor = activityHandler;
                    activityHandler.Successor = priceHandler;

                    List<Item> itemsSport = _itemService.GetItemsByCategoryName(categoryModel.Name);
                    List<Item> filteredSportItems = brandHandler.HandleRequest(_itemService, sportSearchModel, itemsSport);
                    ViewBag.Category = categoryModel;
                    ViewBag.SportSearchModel = sportSearchModel;
                    return View("ItemCategory",
                        filteredSportItems); //.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));

                }

                case CategoryName.Clothes:
                {
                    ItemSearchModel clothesSearchModel = new ItemClothesSearchModel()
                    {
                        Brands = brands,
                        Gender = gender, Sizes = sizes,
                        MinPrice = minPrice, MaxPrice = maxPrice
                    };
                    GenderHandler genderHandler = new GenderHandler();
                    SizeHandler sizeHandler = new SizeHandler();

                    brandHandler.Successor = genderHandler;
                    genderHandler.Successor = sizeHandler;
                    sizeHandler.Successor = priceHandler;
                    
                    List<Item> itemsClothes = _itemService.GetItemsByCategoryName(categoryModel.Name);
                    List<Item> filteredClothesItems = brandHandler.HandleRequest(_itemService, clothesSearchModel, itemsClothes);
                    ViewBag.Category = categoryModel;
                    ViewBag.ClothesSearchModel = clothesSearchModel;
                    return View("ItemCategory",
                        filteredClothesItems); //.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
                }

                case CategoryName.Decorations:
                {
                    ItemSearchModel decorationsSearchModel = new ItemDecorationsSearchModel()
                    {
                        Brands = brands,
                        Materials = materials, Colors = colors,
                        MinPrice = minPrice, MaxPrice = maxPrice
                    };
                    MaterialHandler materialHandler = new MaterialHandler();
                    ColorHandler colorHandler = new ColorHandler();

                    brandHandler.Successor = materialHandler;
                    materialHandler.Successor = colorHandler;
                    colorHandler.Successor = priceHandler;
                    
                    List<Item> itemsDecorations = _itemService.GetItemsByCategoryName(categoryModel.Name);
                    List<Item> filteredDecorationsItems =
                        brandHandler.HandleRequest(_itemService, decorationsSearchModel, itemsDecorations);
                    ViewBag.Category = categoryModel;
                    ViewBag.DecorationsSearchModel = decorationsSearchModel;
                    return View("ItemCategory",
                        filteredDecorationsItems); //.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
                }

                default:
                {
                    ViewBag.Category = categoryModel;
                    return View("ItemCategory",
                        _itemService.GetItems()); //.ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
                }
            }
        }
        catch (Exception e)
        {
            //return View("ItemCategory",
            //    _itemService.GetItems().ConvertAll(model => _itemWebModelMapper.ToWebModel(model)));
            Console.WriteLine(e + "\n" + "------------------------------"); //TODO redirect to error page
            //throw;
            return Ok(null);
        }
        

        //Category? categoryModel = _itemService.GetCategoryByName(category);
    }

    
    [HttpGet("/search")]
    public IActionResult Search(string request)
    {
        List<string> requestKeywords = request.Split(" ").ToList();

        List<Item> filteredItems = _itemService.SearchByKeywords(requestKeywords);

        StringBuilder result = new StringBuilder();
        foreach (var item in filteredItems)
        {
            result.Append($"{item.Name} - {item.Brand} - {item.Price} \n");
        }
        //return result.ToString();

        return View("ItemCategory", filteredItems); //.ConvertAll(_itemWebModelMapper.ToWebModel));
    }
    
    
}
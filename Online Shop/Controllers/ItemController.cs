using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.WebMappers;
using OnlineShopDAL.Utility;
using OnlineShopLogic.Implementation.Services;

namespace OnlineShop.Controllers;

[Controller]
public class ItemController : Controller
{
    private readonly ILogger<ItemController> _logger;
    private ItemService _itemService;
    public ItemController(ILogger<ItemController> logger, ItemService itemService)
    {
        _itemService = itemService;
        _logger = logger;
    }

    [HttpGet]
    public bool FillDatabase()
    {
        return _itemService.FillDatabase();
    }
    
    [HttpGet]
    public IActionResult ItemCategory([FromQuery] string category)
    {
        /*
        Guid categoryId = Guid.NewGuid();
        List<ItemWebModel> items = new List<ItemWebModel>
        {
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "Some product", Description = "some product description",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "other product", Description = "description for other product",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "other product", Description = "description for other product",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "Some product", Description = "some product description",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "other product", Description = "description for other product",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "Some product", Description = "some product description",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "other product", Description = "description for other product",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "Some product", Description = "some product description",
                CategoryId = categoryId
            },
            new ItemWebModel()
            {
                Id = Guid.NewGuid(), Name = "other product", Description = "description for other product",
                CategoryId = categoryId
            }
        };
        ViewBag.Category = category;
        */

        ItemWebModelMapper itemWebModelMapper = new ItemWebModelMapper();
        List<ItemWebModel> items = 
            _itemService.GetItems().ConvertAll(model => itemWebModelMapper.ToWebModel(model));
        
        return View(items);
    }

    public IActionResult ItemPage([FromQuery] string itemId)
    {
        ItemWebModel item = new ItemWebModel()
        {
            Id = Guid.NewGuid(), Name = "product product", Description =
                "Description description description description," +
                "description dddddd dddd dddd ddd d ddddddd d ddd. DDdddd ddd d dddd.",
            CategoryId = Guid.NewGuid(), Price = 2321
        };
        return View(item);
    }
    
}
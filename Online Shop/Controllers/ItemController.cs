using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Models.WebMappers;
using OnlineShopLogic.Utility;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Implementation.Services;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace Online_Shop.Controllers;

[Controller]
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

    [HttpGet]
    public bool FillDatabase()
    {
        return _itemService.FillDatabase();
    }

    [HttpGet]
    public IActionResult ItemCategory([FromQuery] string categoryString)
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

        //Category category = _itemService.GetItemsByCategory(category)

        ItemWebModelMapper itemWebModelMapper = new ItemWebModelMapper();
        List<ItemWebModel> items =
            _itemService.GetItemsByCategory(categoryString).ConvertAll(model => itemWebModelMapper.ToWebModel(model));
        //_itemService.GetItems().ConvertAll(model => itemWebModelMapper.ToWebModel(model));

        Category? category = _itemService.GetCategoryByName(categoryString);
        if(category != null)
        {
            ViewBag.Category = category;
        }
        else
        {
            //TODO Error page or something
        }
        return View(items);
    }

    public IActionResult ItemPage([FromQuery] string itemId)
    {
        /*
        ItemWebModel itemTest = new ItemWebModel()
        {
            Id = Guid.NewGuid(), Name = "product product", Description =
                "Description description description description," +
                "description dddddd dddd dddd ddd d ddddddd d ddd. DDdddd ddd d dddd.",
            CategoryId = Guid.NewGuid(), Price = 2321
        };
        */

        //ItemWebModel itemWebModel = _itemWebModelMapper.ToWebModel(_itemService.GetItem(Guid.Parse(itemId)));
        Item item = _itemService.GetItem(Guid.Parse(itemId));


        return View(item);
    }
}
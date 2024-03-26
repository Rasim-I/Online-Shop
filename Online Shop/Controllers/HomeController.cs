using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineShop.Models.Enums;
using OnlineShopLogic.Abstraction.IServices;

namespace Online_Shop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IHomeService _homeService;
    
    public HomeController(ILogger<HomeController> logger, IHomeService homeService)
    {
        _logger = logger;
        _homeService = homeService;
    }

    public IActionResult Index()
    {
        
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
        /*
        CategoryWebModel category1 = new CategoryWebModel() { Id = Guid.NewGuid(), Name = "Electronics" };
        CategoryWebModel category2 = new CategoryWebModel() { Id = Guid.NewGuid(), Name = "Sport" };
        CategoryWebModel category3 = new CategoryWebModel() { Id = Guid.NewGuid(), Name = "Decorations" };
        List<CategoryWebModel> categories = new List<CategoryWebModel>();
        categories.Add(category1);
        categories.Add(category2);
        categories.Add(category3);
        ViewBag.Categories = categories;
        */

        ViewBag.Categories = _homeService.GetRootCategories();  //Remove CategoryWebModel
        return View(items);
    }

    [Route("/test")]
    public IActionResult Test()
    {
        return View("TestCss");
    }

    /*
    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 3;

        IQueryable<Product> source; //db.Products.Include(x => something);
        var count = await source.CountAsync();
        var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
        IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
        return View(viewModel);
    }
    */

    /*
    public async Task<IActionResult> Index(string name, int company = 0, int page = 1, SortState sortOrder =SortState.NameAsc)
    {
        int pageSize = 3;
        
        //filtration
        IQueryable<Product> products = db.Products.Include(something);

        if (product != 0)
        {
            products = products.Where(p => p.ProductId == product);
        }

        if (!string.IsNullOrEmpty(name))
        {
            products = products.Where(p => p.Name!.Contains(name));
        }

        //sort
        switch (sortOrder)
        {
            case SortState.NameDesc:
                products = products.OrderByDescending(s => s.Name);
                break;
            case SortState.AgeAsc:
                products = products.OrderBy(s => s.Age);
                break;
            case SortState.AgeDesc:
                products = products.OrderByDescending(s => s.Age);
                break;
            case SortState.ProductAsc:
                products = products.OrderBy(s => s.Company!.Name);
                break;
            case SortState.ProductDesc:
                products = products.OrderByDescending(s => s.Company!.Name);
                break;
            default:
                products = products.OrderBy(s => s.Name);
                break;
        }
        
        //pagination
        var count = await products.CountAsync();
        var items = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        //model formation
        IndexViewModel viewModel = new IndexViewModel(
            items,
            new PageViewModel(count, page, pageSize),
            new FilterViewModel(db.Products.ToList(), company, name),
            new SortViewModel(sortOrder)
        );
        return View(viewModel);
    }
*/

    public IActionResult Privacy()
    {
        return View("TestCss");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
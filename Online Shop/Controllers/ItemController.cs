using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers;

[Controller]
public class ItemController : Controller
{
    private readonly ILogger<ItemController> _logger;

    public ItemController(ILogger<ItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult ItemCategory([FromQuery] string categoryId)
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace Online_Shop.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }
    
}
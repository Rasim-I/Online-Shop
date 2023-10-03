namespace OnlineShopDAL;
using Microsoft.EntityFrameworkCore;

public class OnlineShopContext : DbContext
{
    public OnlineShopContext(DbContextOptions<OnlineShopContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    

}
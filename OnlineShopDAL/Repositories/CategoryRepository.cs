using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CategoryRepository : Repository<CategoryEntity, Guid>, ICategoryRepository
{
    public CategoryRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
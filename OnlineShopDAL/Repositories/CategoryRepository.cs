using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CategoryRepository : Repository<CategoryEntity, Guid>, ICategoryRepository
{
    public CategoryRepository(OnlineShopContext context) : base(context)
    {
        
    }

    public List<CategoryEntity> GetRootCategories()
    {
        return db.Categories.Where(c => c.IsRoot == true).ToList();
    }
    
}
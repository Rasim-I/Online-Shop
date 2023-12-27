using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CategoryRepository : Repository<CategoryEntity, Guid>, ICategoryRepository
{
    public CategoryRepository(OnlineShopContext context) : base(context)
    {
        
    }

    public IEnumerable<CategoryEntity> GetRootCategories()
    {
        return db.Categories.Where(c => c.IsRoot == true);
    }

    public List<CategoryEntity> GetCategoryByName(CategoryName categoryName)
    {
        return db.Categories.Where(c => c.Name.Equals(categoryName)).ToList();
    }

}
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.IRepositories;

public interface ICategoryRepository : IRepository<CategoryEntity, Guid>
{
    public IEnumerable<CategoryEntity> GetRootCategories();

    public List<CategoryEntity> GetCategoryByName(CategoryName categoryName);
}
using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface ICategoryRepository : IRepository<CategoryEntity, Guid>
{
    public List<CategoryEntity> GetRootCategories();
}
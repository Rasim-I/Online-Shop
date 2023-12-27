using Microsoft.EntityFrameworkCore;
using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class ItemRepository : Repository<ItemEntity, Guid>, IItemRepository
{
    public ItemRepository(OnlineShopContext context) : base(context)
    {
        
    }

    public IEnumerable<ItemEntity> GetAll_IncludeAll()
    {
        return db.Items
            .Include(i => i.Category)
            .Include(i => i.Photos);

    }

    public ItemEntity? GetById(Guid itemId)
    {
        return db.Items.Where(i => i.Id == itemId)
            .Include(i => i.Category)
            .Include(i => i.Photos)
            .FirstOrDefault();
    }

    public IEnumerable<ItemEntity> GetByCategory(Guid categoryId)
    {
        return db.Items.Where(i => i.Category.Id == categoryId)
            .Include(i => i.Category)
            .Include(i => i.Photos);
    }

}
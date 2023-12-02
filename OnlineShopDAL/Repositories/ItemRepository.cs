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
            .Include(i => i.Photos)
            .Include(i =>i.Category.SubCategories);
    }

    public ItemEntity? GetById(Guid itemId)
    {
        return db.Items.Where(i => i.Id == itemId)
            .Include(i => i.Category)
            .Include(i => i.Photos)
            .Include(i => i.Category.SubCategories).FirstOrDefault();
    }

}
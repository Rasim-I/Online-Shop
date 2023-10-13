using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class PhotoRepository : Repository<PhotoEntity, Guid>, IPhotoRepository
{
    public PhotoRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
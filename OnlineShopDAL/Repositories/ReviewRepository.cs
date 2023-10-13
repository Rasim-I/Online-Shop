using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class ReviewRepository : Repository<ReviewEntity, Guid>, IReviewRepository
{
    public ReviewRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL;

public interface IUnitOfWork
{ 
    ICartRepository Carts { get; }
    
    ICategoryRepository Categories { get; }
    
    ICustomerRepository Customers { get; }
    
    IItemRepository Items { get; }

    IOrderRepository Orders { get; }

    IPhotoRepository Photos { get; }
    
    IReviewRepository Reviews { get; }

    int Save();

}
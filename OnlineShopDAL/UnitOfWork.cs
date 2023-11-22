using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;
using OnlineShopDAL.Repositories;

namespace OnlineShopDAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly OnlineShopContext _context;
    
    public ICartRepository Carts { get; private set; }
    
    public ICategoryRepository Categories { get; private set; }
    
    public ICustomerRepository Customers { get; private set; }
    
    public IItemRepository Items { get; private set; }
    
    public IOrderRepository Orders { get; private set; }
    
    public IPhotoRepository Photos { get; private set; }
    
    public IReviewRepository Reviews { get; private set; }

    public UnitOfWork(OnlineShopContext context)
    {
        _context = context;
        Carts = new CartRepository(_context);
        Categories = new CategoryRepository(context);
        Customers = new CustomerRepository(context);
        Items = new ItemRepository(context);
        Orders = new OrderRepository(context);
        Photos = new PhotoRepository(context);
        Reviews = new ReviewRepository(context);

    }
    
    public int Save()
    {
        return _context.SaveChanges();
    }

    private bool disposed = false;

    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
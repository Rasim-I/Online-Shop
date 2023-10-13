using OnlineShopDAL.Entities;
using OnlineShopDAL.IRepositories;

namespace OnlineShopDAL.Repositories;

public class CustomerRepository : Repository<CustomerEntity, Guid>, ICustomerRepository
{
    public CustomerRepository(OnlineShopContext context) : base(context)
    {
        
    }
    
}
using OnlineShopDAL.Entities;

namespace OnlineShopDAL.IRepositories;

public interface ICustomerRepository : IRepository<CustomerEntity, Guid>
{
    
}
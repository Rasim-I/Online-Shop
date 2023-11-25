using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Mappers;

public class CustomerMapper : IMapper<CustomerEntity, Customer>
{
    public CustomerEntity ToEntity(Customer model)
    {
        return new CustomerEntity()
        {
            Id = model.Id,
            Name = model.Name,
            Surname = model.Surname,
            SecondName = model.SecondName,
            BirthDate = model.BirthDate,
            RegistrationDate = model.RegistrationDate,
            Gender = (Gender)model.Gender,
            ApplicationUserId = model.ApplicationUserId
        };
    }

    public Customer ToModel(CustomerEntity entity)
    {
        return new Customer()
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            SecondName = entity.SecondName,
            BirthDate = entity.BirthDate,
            RegistrationDate = entity.RegistrationDate,
            Gender = (Models.Enums.Gender)entity.Gender,
            ApplicationUserId = entity.ApplicationUserId
        };
    }
}
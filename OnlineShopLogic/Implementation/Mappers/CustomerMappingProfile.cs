using AutoMapper;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Implementation.Mappers;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerEntity, Customer>()
            .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(src => (Gender)src.Gender));

        CreateMap<Customer, CustomerEntity>()
            .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(src => (OnlineShopDAL.Entities.Enums.Gender)src.Gender));
    }
    
}
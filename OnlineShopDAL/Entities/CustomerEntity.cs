using OnlineShopDAL.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopDAL.Entities;

[Table("Customers")]
public class CustomerEntity
{
    public Guid Id { get; set; }
    
    public DateTime RegistrationDate { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string SecondName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }  

    
    public Guid ApplicationUserId { get; set; }
    

}
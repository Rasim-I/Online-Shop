using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using OnlineShopModels.Models.Enums;

namespace Online_Shop.Areas.Identity.Data;

//[Table("Customer")]
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(30)")]
    public string Name { get; set; }
    
    [PersonalData]
    [Column(TypeName = "nvarchar(30)")]
    public string Surname { get; set; }
    
    [PersonalData]
    [Column(TypeName = "nvarchar(30)")]
    public string SecondName { get; set; }
    
    [PersonalData]
    [Column(TypeName = "date")]
    public DateTime RegistrationDate { get; set; }
    
    [PersonalData]
    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }
    
    [PersonalData]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    
}
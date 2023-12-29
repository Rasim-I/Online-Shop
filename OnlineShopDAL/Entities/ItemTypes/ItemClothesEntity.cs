using System.Drawing;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.Entities.ItemTypes;

public class ItemClothesEntity : ItemEntity
{
    public string Gender { get; set; }
    public string Size { get; set; }
}
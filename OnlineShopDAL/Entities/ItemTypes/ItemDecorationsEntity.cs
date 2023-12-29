using System.Drawing;
using OnlineShopDAL.Entities.Enums.ItemParameters.ItemDecorations;

namespace OnlineShopDAL.Entities.ItemTypes;

public class ItemDecorationsEntity: ItemEntity
{
    public string Color { get; set; }
    public string Material { get; set; }
}
using OnlineShopModels.Models;

namespace OnlineShop.Models.WebMappers;

public class ItemWebModelMapper
{
    public ItemWebModel ToWebModel(Item model)
    {
        return new ItemWebModel()
        {
            Id = model.Id,
            CategoryId = model.Category.Id,
            Description = model.Description,
            Name = model.Name,
            Photos = model.Photos,
            Price = model.Price
        };
    }
}
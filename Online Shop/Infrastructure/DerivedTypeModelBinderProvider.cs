using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using OnlineShopModels.Models;
using OnlineShopModels.Models.ItemTypes;

namespace Online_Shop;

public class DerivedTypeModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType != typeof(Item))
            return null;

        return new DerivedTypeModelBinder();
    }

}
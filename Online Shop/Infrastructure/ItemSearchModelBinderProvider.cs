using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;

namespace Online_Shop.Infrastructure;

public class ItemSearchModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(ItemSearchModel))
        {
            return new ItemSearchModelBinder();
        }

        return null;
    }
    
    
}
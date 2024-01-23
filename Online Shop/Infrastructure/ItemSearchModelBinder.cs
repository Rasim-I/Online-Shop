using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;

namespace Online_Shop.Infrastructure;

public class ItemSearchModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ItemSearchModel baseModel;

        if (bindingContext.HttpContext.Request.Form.ContainsKey("CpuModels") ||
            bindingContext.HttpContext.Request.Form.ContainsKey("MemoryCapacities"))
        {
            baseModel = new ItemElectronicsSearchModel();
            ((ItemElectronicsSearchModel)baseModel).CpuModels = 
                bindingContext.HttpContext.Request.Form["CpuModels"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
            ((ItemElectronicsSearchModel)baseModel).MemoryCapacities = 
                bindingContext.HttpContext.Request.Form["MemoryCapacities"].FirstOrDefault()?.Split(",").ToList() ??  new List<string>();
            
        }
        else if (bindingContext.HttpContext.Request.Form.ContainsKey("Sizes") ||
                 bindingContext.HttpContext.Request.Form.ContainsKey("Gender"))
        {
            baseModel = new ItemClothesSearchModel();
            ((ItemClothesSearchModel)baseModel).Sizes = 
                bindingContext.HttpContext.Request.Form["Sizes"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
            ((ItemClothesSearchModel)baseModel).Gender = bindingContext.HttpContext.Request.Form["Gender"].FirstOrDefault()?.ToString() ?? "";
        }
        else if (bindingContext.HttpContext.Request.Form.ContainsKey("Activities"))
        {
            baseModel = new ItemSportSearchModel();
            ((ItemSportSearchModel)baseModel).Activities = 
                bindingContext.HttpContext.Request.Form["Activities"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
        }
        else if (bindingContext.HttpContext.Request.Form.ContainsKey("Materials") ||
                 bindingContext.HttpContext.Request.Form.ContainsKey("Colors"))
        {
            baseModel = new ItemDecorationsSearchModel();
            ((ItemDecorationsSearchModel)baseModel).Materials = 
                bindingContext.HttpContext.Request.Form["Materials"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
            ((ItemDecorationsSearchModel)baseModel).Colors = 
                bindingContext.HttpContext.Request.Form["Colors"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
        }
        else
        {
            baseModel = new ItemSearchModel();
        }

        //baseModel.Name = bindingContext.HttpContext.Request.Form["Name"];
        baseModel.Brands = 
            bindingContext.HttpContext.Request.Form["Brands"].FirstOrDefault()?.Split(",").ToList() ?? new List<string>();

        var minPriceValue = bindingContext.HttpContext.Request.Form["MinPrice"].FirstOrDefault();
        var maxPriceValue = bindingContext.HttpContext.Request.Form["MaxPrice"].FirstOrDefault();
        baseModel.MinPrice = !string.IsNullOrEmpty(minPriceValue) ? Convert.ToInt32(minPriceValue) : 0;
        baseModel.MaxPrice = !string.IsNullOrEmpty(maxPriceValue) ? Convert.ToInt32(maxPriceValue) : 0; //It will be handled in PriceHandler anyway //Int32.MaxValue;
        
        
        bindingContext.Result = ModelBindingResult.Success(baseModel);
        return Task.CompletedTask;
    }
    
    
}
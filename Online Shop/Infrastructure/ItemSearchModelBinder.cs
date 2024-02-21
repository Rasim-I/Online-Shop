using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;
using OnlineShopModels.Models.Enums;

namespace Online_Shop.Infrastructure;

public class ItemSearchModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ItemSearchModel baseModel;

        //var categoryName = "";
        //bindingContext.HttpContext.Request.Form.TryGetValue("Name", out var categoryName);
        
        if (//bindingContext.HttpContext.Request.Form.ContainsKey("CpuModels") ||
            //bindingContext.HttpContext.Request.Form.ContainsKey("MemoryCapacities") ||
            bindingContext.HttpContext.Request.Form["Name"].Equals(CategoryName.Electronics.ToString()))
        {
            baseModel = new ItemElectronicsSearchModel();
            ((ItemElectronicsSearchModel)baseModel).CpuModels = 
                bindingContext.HttpContext.Request.Form["CpuModels"].ToList() ?? new List<string>();
            ((ItemElectronicsSearchModel)baseModel).MemoryCapacities = 
                bindingContext.HttpContext.Request.Form["MemoryCapacities"].ToList() ??  new List<string>();
            
        }
        else if (bindingContext.HttpContext.Request.Form["Name"].Equals(CategoryName.Clothes.ToString()))
        {
            baseModel = new ItemClothesSearchModel();
            ((ItemClothesSearchModel)baseModel).Sizes = 
                bindingContext.HttpContext.Request.Form["Sizes"].ToList() ?? new List<string>();
            ((ItemClothesSearchModel)baseModel).Gender = bindingContext.HttpContext.Request.Form["Gender"].FirstOrDefault()?.ToString() ?? "";
        }
        else if (bindingContext.HttpContext.Request.Form["Name"].Equals(CategoryName.Sport.ToString()))
        {
            baseModel = new ItemSportSearchModel();
            ((ItemSportSearchModel)baseModel).Activities = 
                bindingContext.HttpContext.Request.Form["Activities"].ToList() ?? new List<string>(); 
            //.FirstOrDefault()?.Split(",").ToList() ?? new List<string>();
        }
        else if (bindingContext.HttpContext.Request.Form["Name"].Equals(CategoryName.Decorations.ToString()))
        {
            baseModel = new ItemDecorationsSearchModel();
            ((ItemDecorationsSearchModel)baseModel).Materials = 
                bindingContext.HttpContext.Request.Form["Materials"].ToList() ?? new List<string>();
            ((ItemDecorationsSearchModel)baseModel).Colors = 
                bindingContext.HttpContext.Request.Form["Colors"].ToList() ?? new List<string>();
        }
        else
        {
            baseModel = new ItemSearchModel();
        }

        //baseModel.Name = bindingContext.HttpContext.Request.Form["Name"];
        baseModel.Brands = 
            bindingContext.HttpContext.Request.Form["Brands"].ToList() ?? new List<string>();
        var minPriceValue = bindingContext.HttpContext.Request.Form["MinPrice"].FirstOrDefault();
        var maxPriceValue = bindingContext.HttpContext.Request.Form["MaxPrice"].FirstOrDefault();
        baseModel.MinPrice = !string.IsNullOrEmpty(minPriceValue) ? Convert.ToInt32(minPriceValue) : 0;
        baseModel.MaxPrice = !string.IsNullOrEmpty(maxPriceValue) ? Convert.ToInt32(maxPriceValue) : 0; //It will be handled in PriceHandler anyway //Int32.MaxValue;
        
        
        bindingContext.Result = ModelBindingResult.Success(baseModel);
        return Task.CompletedTask;
    }
    
    
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using OnlineShopLogic.Models;
using OnlineShopLogic.Models.ItemTypes;

namespace Online_Shop;

public class DerivedTypeModelBinder : IModelBinder
{
    
    //private readonly IModelBinder fallbackBinder;

    //public DerivedTypeModelBinder(IModelBinder fallbackBinder)
    //{
    //    this.fallbackBinder = fallbackBinder;
    //}

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        //Retrieving the value from the value provider
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        
        //if (valueProviderResult == ValueProviderResult.None)
        //{   
            //Fall back to the default binder if no value is found
        //    return fallbackBinder.BindModelAsync(bindingContext);
        //}

        var valueAsString = valueProviderResult.FirstValue;

        //Implement your logic to determine the actual derived type based on the value
        //For simplicity, let's assume you have a property "ItemType" in the model indicating the type
        if (bindingContext.ModelType.IsAssignableFrom(typeof(Item)))
        {
            if (valueAsString == "Electronics")
            {
                bindingContext.Result = ModelBindingResult.Success(new ItemElectronics());
            }
            else if (valueAsString == "Sport")
            {
                bindingContext.Result = ModelBindingResult.Success(new ItemSport());
            }
            //Add more conditions for other derived types
            
        }

        return Task.CompletedTask;
    }
    

    /*
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        using var sr = new StreamReader(bindingContext.HttpContext.Request.Body);
        var json = await sr.ReadToEndAsync();
        JObject requestJObject = JObject.Parse(json);
        string? type = requestJObject["entityType"]?.ToObject<string>();

        Person? person = type
            switch
            {
                nameof(Employee) => JsonConvert.DeserializeObject<Employee>(json),
                nameof(Student) => JsonConvert.DeserializeObject<Student>(json),
                _ =>
                    throw new Exception()
            };

        bindingContext.Result = ModelBindingResult.Success(person);
    }
}
*/
}
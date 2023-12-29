using OnlineShopDAL.Entities.Enums.ItemParameters.ItemElectronics;

namespace OnlineShopDAL.Entities.ItemTypes;

public class ItemElectronicsEntity : ItemEntity
{
    public string CpuModel { get; set; }
    public string MemoryCapacity { get; set; }
    
}
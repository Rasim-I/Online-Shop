namespace OnlineShopDAL.Entities.ItemTypes;

public class ElectronicsItemEntity : ItemEntity
{
    public string CpuModel { get; set; }
    public int MemoryCapacity { get; set; }
}
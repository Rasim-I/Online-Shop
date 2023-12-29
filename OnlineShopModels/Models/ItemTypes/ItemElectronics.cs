namespace OnlineShopModels.Models.ItemTypes;


public class ItemElectronics : Item
{
    private string _cpuModel;
    private string _memoryCapacity;

    public string CpuModel
    {
        get => _cpuModel;
        set => _cpuModel = value;
    }

    public string MemoryCapacity
    {
        get => _memoryCapacity;
        set => _memoryCapacity = value;
    }

    /*
    public ItemElectronics()
    {
        ItemType = "ItemElectronics";
    }
    */
}
namespace OnlineShopLogic.Models.ItemTypes;


public class ItemElectronics : Item
{
    private string _cpuModel;
    private int _memoryCapacity;

    public string CpuModel
    {
        get => _cpuModel;
        set => _cpuModel = value;
    }

    public int MemoryCapacity
    {
        get => _memoryCapacity;
        set => _memoryCapacity = value;
    }

}
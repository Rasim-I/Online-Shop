namespace OnlineShopLogic.Models.Categories;

public class CategoryItemElectronics : Category
{
    private string _cpuModel;
    private int _memoryCapacity;

    public string CpuModel
    {
        get => _cpuModel;
        set => value = _cpuModel;
    }

    public int MemoryCapacity
    {
        get => _memoryCapacity;
        set => value = _memoryCapacity;
    }
    
}
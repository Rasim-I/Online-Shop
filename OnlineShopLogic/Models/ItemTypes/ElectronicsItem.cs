namespace OnlineShopLogic.Models.ItemTypes;

public class ElectronicsItem : Item
{
    private string _cpuModel;
    private int _memory;
    
    public string CpuModel { get; set; }
    public int MemoryCapacity { get; set; }

    public ElectronicsItem(string name, string description, int price, Category category, int quantity) : 
        base(name, description, price, category, quantity)
    {
        
    }
    
}
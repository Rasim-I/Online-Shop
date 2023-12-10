namespace OnlineShopLogic.Models.ItemTypes;

public class SportItem : Item
{
    private string _category;
    
    public string Category { get; set; }

    public SportItem(string name, string description, int price, Category category, int quantity) :
        base(name, description, price, category, quantity)
    {
        
    }
    
}
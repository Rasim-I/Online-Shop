namespace OnlineShopLogic.Models.ItemTypes;

public class DecorationsItem : Item
{
    private string _material;
    private string _color;
    
    public string Material { get; set; }
    public string Color { get; set; }

    public DecorationsItem(string name, string description, int price, Category category, int quantity) :
        base(name, description, price, category, quantity)
    {
        
    }
}
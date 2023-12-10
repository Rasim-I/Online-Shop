namespace OnlineShopLogic.Models.ItemTypes;

public class ClothesItem : Item
{
    private string _size;
    private string _gender;
    
    public string Size { get; set; }
    public string Gender { get; set; }

    public ClothesItem(string name, string description, int price, Category category, int quantity) :
        base(name, description, price, category, quantity)
    {
        
    }
}
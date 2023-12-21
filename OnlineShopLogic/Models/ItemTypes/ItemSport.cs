namespace OnlineShopLogic.Models.ItemTypes;

public class ItemSport : Item
{
    private string _category;

    public string Category
    {
        get => _category;
        set => _category = value;
    }
    
}
namespace OnlineShopModels.Models.ItemTypes;

public class ItemDecorations : Item
{

    private string _color;
    private string _material;

    public string Color
    {
        get => _color;
        set => _color = value;
    }

    public string Material
    {
        get => _material;
        set => _material = value;
    }
    
    
    /*
    public ItemDecorations()
    {
        ItemType = "ItemDecorations";
    }
    */

}
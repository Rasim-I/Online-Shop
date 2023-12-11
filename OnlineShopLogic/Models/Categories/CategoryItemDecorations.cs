namespace OnlineShopLogic.Models.Categories;

public class CategoryItemDecorations : Category
{
    private string _color;
    private string _material;

    public string Color
    {
        get => _color;
        set => _material = value;
    }

    public string Material
    {
        get => _material;
        set => _material = value;
    }
    
}

namespace OnlineShopModels.Models.ItemTypes;

public class ItemClothes : Item
{
    private string _gender;
    private string _size;

    public string Gender
    {
        get => _gender;
        set => _gender = value;
    }

    public string Size
    {
        get => _size;
        set => _size = value;
    }

    /*
    public ItemClothes()
    {
        ItemType = "ItemClothes";
    }
    */
}
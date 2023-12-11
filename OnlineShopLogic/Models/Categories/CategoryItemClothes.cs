namespace OnlineShopLogic.Models.Categories;

public class CategoryItemClothes : Category
{
    private string _size;
    private string _gender;

    public string Size
    {
        get => _size;
        set => _size = value;
    }
}
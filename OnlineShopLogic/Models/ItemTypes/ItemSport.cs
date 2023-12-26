namespace OnlineShopLogic.Models.ItemTypes;

public class ItemSport : Item
{
    private string _activity;

    public string Activity
    {
        get => _activity;
        set => _activity = value;
    }

    /*
    public ItemSport()
    {
        ItemType = "ItemSport";
    }
    */
}
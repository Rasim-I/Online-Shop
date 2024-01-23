namespace OnlineShopLogic.Implementation.FilterChain.ItemSearchModels;

public class ItemClothesSearchModel : ItemSearchModel
{
    public string Gender { get; set; }
    public List<string> Sizes { get; set; }
}
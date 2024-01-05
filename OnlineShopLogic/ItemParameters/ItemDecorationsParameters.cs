namespace OnlineShopLogic.ItemParameters;

public class ItemDecorationsParameters
{

    public const string ReyBrand = "Rey";
    public const string DivalisBrand = "Divalis";

    public static List<string> Brands = new List<string>()
        { ReyBrand, DivalisBrand };

    public const string WhiteColor = "White";
    public const string BlackColor = "Black";
    public const string BlueColor = "Blue";
    public const string GreenColor = "Green";

    public static List<string> Colors = new List<string>()
        { WhiteColor, BlackColor, BlackColor, GreenColor };


    public const string PlasticMaterial = "Plastic";
    public const string WoodMaterial = "Wood";
    public const string MetalMaterial = "Metal";

    public static List<string> Materials = new List<string>()
        { PlasticMaterial, WoodMaterial, MetalMaterial };

}
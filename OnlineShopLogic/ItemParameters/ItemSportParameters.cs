namespace OnlineShopLogic.ItemParameters;

public class ItemSportParameters
{
    
    public const string EverlastBrand = "Everlast";
    public const string PumaBrand = "Puma";
    public const string MikasaBrand = "Mikasa";
    public const string DonicBrand = "Donic";

    public static List<string> Brands = new List<string>()
        { EverlastBrand, PumaBrand, MikasaBrand, DonicBrand };
    
    
    public const string HeavyLiftingActivity = "Heavy lifting";
    public const string TableTennisActivity = "Table tennis";
    public const string SoccerActivity = "Soccer";

    public static List<string> Activities = new List<string>()
        { HeavyLiftingActivity, TableTennisActivity, SoccerActivity };
}
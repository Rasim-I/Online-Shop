namespace OnlineShopLogic.ItemParameters;

public class ItemElectronicsParameters
{

    public const string AsusBrand = "Asus";
    public const string HPBrand = "HP";
    public const string SamsungBrand = "Samsung";
    public const string LenovoBrand = "Lenovo";

    public static List<string> Brands = new List<string>()
        { AsusBrand, HPBrand, SamsungBrand, LenovoBrand };
    
    
    public const string AMDCpuModel = "AMD";
    public const string IntelCpuModel = "Intel";
    public const string SnapdragonCpuModel = "Snapdragon";
    public const string MediaTekCpuModel = "MediaTek";

    public static List<string> CpuModels = new List<string>()
        { AMDCpuModel, IntelCpuModel, SnapdragonCpuModel, MediaTekCpuModel };
    
    
    
    public const string Memory64 = "64 GB";
    public const string Memory128 = "128 GB";
    public const string Memory512 = "512 GB";

    public static List<string> MemoryCapacity = new List<string>() 
        { Memory64, Memory128, Memory512 };

}
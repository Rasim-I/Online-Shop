namespace OnlineShopLogic.ItemParameters;

public class ItemClothesParameters
{

    public const string CropBrand = "Crop";
    public const string NikeBrad = "Nike";
    public const string DiadoraBrand = "Diadora";

    public static List<string> Brands = new List<string>()
        { CropBrand, NikeBrad, DiadoraBrand };


    public const string MaleGender = "Male";
    public const string FemaleGender = "Female";

    public static List<string> Genders = new List<string>()
        { MaleGender, FemaleGender };

    
    public const string SizeS = "S";
    public const string SizeM = "M";
    public const string SizeL = "L";
    public const string SizeXL = "XL";

    public static List<string> Sizes = new List<string>()
        { SizeS, SizeM, SizeL, SizeXL };
}
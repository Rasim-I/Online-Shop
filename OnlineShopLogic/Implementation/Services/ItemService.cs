using OnlineShopDAL;
using OnlineShopDAL.Utility;

namespace OnlineShopLogic.Implementation.Services;

public class ItemService
{
    private IUnitOfWork _unitOfWork;
    
    public ItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        

    }

    

    public bool FillDatabase()
    {
        try
        {
            InitData initData = new InitData(_unitOfWork);
            initData.FillDatabase();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return false;
        }
        
    }
    
}

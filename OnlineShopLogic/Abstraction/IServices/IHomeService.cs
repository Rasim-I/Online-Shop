
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Abstraction.IServices;

public interface IHomeService
{
    public List<Category> GetRootCategories();

}
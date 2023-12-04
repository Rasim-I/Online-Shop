using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopLogic.Models;

namespace OnlineShopLogic.Implementation.Services;

public class HomeService : IHomeService
{
    private IUnitOfWork _unitOfWork;
    private IMapper<CategoryEntity, Category> _categoryMapper;

    public HomeService(IUnitOfWork unitOfWork, IMapper<CategoryEntity, Category> categoryMapper)
    {
        _unitOfWork = unitOfWork;
        _categoryMapper = categoryMapper;
    }

    public List<Category> GetRootCategories()
    {
        List<CategoryEntity> categoryEntities = _unitOfWork.Categories.GetRootCategories();

        return categoryEntities.ConvertAll(_categoryMapper.ToModel);
    }
    
}
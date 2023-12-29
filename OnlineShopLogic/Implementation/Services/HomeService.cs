using AutoMapper;
using OnlineShopDAL;
using OnlineShopDAL.Entities;
using OnlineShopLogic.Abstraction.IMappers;
using OnlineShopLogic.Abstraction.IServices;
using OnlineShopModels.Models;

namespace OnlineShopLogic.Implementation.Services;

public class HomeService : IHomeService
{
    private IUnitOfWork _unitOfWork;
    //private IMapper<CategoryEntity, Category> _categoryMapper;
    private IMapper _mapper;

    public HomeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public List<Category> GetRootCategories()
    {
        List<CategoryEntity> categoryEntities = _unitOfWork.Categories.GetRootCategories().ToList();

        return categoryEntities.ConvertAll(entity => _mapper.Map<Category>(entity));
    }
    
}
using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;

namespace OnlineShopDAL.Utility;

public class InitData
{
    private IUnitOfWork _unitOfWork;

    public InitData(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void FillDatabase()
    {
        PhotoEntity photoElectronics = new PhotoEntity()
        {
            Id = Guid.NewGuid(), Name = "Electronics",
            Link = "https://drive.google.com/file/d/1E1MyrhZt1bJUulJqy5Dda5wIVBzmvWx0/view?usp=sharing"
        };
        PhotoEntity photoSport = new PhotoEntity()
        {
            Id = Guid.NewGuid(), Name = "Sport",
            Link = "https://drive.google.com/file/d/136Vn4diE2jaJ20UyeLp2TVpuNAK8YrPR/view?usp=sharing"
        };
        PhotoEntity photoDecorations = new PhotoEntity()
        {
            Id = Guid.NewGuid(), Name = "Decorations",
            Link = "https://drive.google.com/file/d/1QzzcRs4PbsEmGE1I8D6_QZeSRaiamlQx/view?usp=sharing"
        };
        PhotoEntity photoClothes = new PhotoEntity()
        {
            Id = Guid.NewGuid(), Name = "Clothes",
            Link = "https://drive.google.com/file/d/1EgCvp7PN3CKQQikQxcWwl0mSzwkbCpIv/view?usp=sharing"
        };

        CategoryEntity categoryElectronics = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Decorations};
        CategoryEntity categorySport = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Sport};
        CategoryEntity categoryDecorations = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Decorations};
        CategoryEntity categoryClothes = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Clothes};


        List<PhotoEntity> photosForElectronics1 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "1",
                Link = "https://drive.google.com/file/d/11HB5-DTRx6aSyoZZ0CzNU93NUi6W2SeC/view?usp=sharing"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "2",
                Link = "https://drive.google.com/file/d/1iAhrxC0gRnM_hz5EaD-O99mK2XxEytc7/view?usp=sharing"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "3",
                Link = "https://drive.google.com/file/d/1fXkHxp36yEb6y04salvOYEj69OXyiqWN/view?usp=sharing"
            }
        };

        ItemEntity itemElectronics1 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Laptop model something Silver Grey",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1200, Quantity = 10, Photos = photosForElectronics1
        };

        ItemEntity itemElectronics2 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Laptop 2 model something Silver Grey",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1400, Quantity = 8, Photos = photosForElectronics1
        };

        ItemEntity itemElectronics3 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Laptop 3 model something Silver Grey",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1250, Quantity = 4, Photos = photosForElectronics1
        };

        List<PhotoEntity> photosForElectronics2 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "1",
                Link = "https://drive.google.com/file/d/1lwDpRSgwHqr0TGNXt7ie14k2rb-14dhs/view?usp=sharing"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "2",
                Link = "https://drive.google.com/file/d/18FY6MjfPru6MLEtOGzNGM93NxAQEvSsX/view?usp=sharing"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "3",
                Link = "https://drive.google.com/file/d/1lHzLtcij3hzo_MhwTC7jTaWwyhAG5xow/view?usp=sharing"
            }
        };

        ItemEntity itemElectronics4 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Tablet model something Matte Gray",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sequis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1000, Quantity = 5, Photos = photosForElectronics2
        };

        ItemEntity itemElectronics5 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Tablet 2 model something Matte Gray",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sequis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1100, Quantity = 4, Photos = photosForElectronics2
        };

        ItemEntity itemElectronics6 = new ItemEntity()
        {
            Id = Guid.NewGuid(), Name = "Tablet 3 model something Matte Gray",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sequis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 900, Quantity = 4, Photos = photosForElectronics2
        };

        List<CategoryEntity> categories = new List<CategoryEntity>();
        categories.Add(categoryElectronics);
        categories.Add(categoryDecorations);
        categories.Add(categorySport);
        categories.Add(categoryClothes);

        List<ItemEntity> items = new List<ItemEntity>();
        items.Add(itemElectronics1);
        items.Add(itemElectronics2);
        items.Add(itemElectronics3);
        items.Add(itemElectronics4);
        items.Add(itemElectronics5);
        items.Add(itemElectronics6);

        /*
        _unitOfWork.Photos.Create(photoDecorations);
        _unitOfWork.Photos.Create(photoElectronics);
        _unitOfWork.Photos.Create(photoClothes);
        _unitOfWork.Photos.Create(photoSport);
        _unitOfWork.Save();
        
        _unitOfWork.Categories.Create(categoryElectronics);
        _unitOfWork.Categories.Create(categorySport);
        _unitOfWork.Categories.Create(categoryDecorations);
        _unitOfWork.Categories.Create(categoryClothes);
        _unitOfWork.Save();
        
        */
        
        foreach (var photo in photosForElectronics1)
        {
            _unitOfWork.Photos.Create(photo);
        }
        foreach (var photo in photosForElectronics2)
        {
            _unitOfWork.Photos.Create(photo);
        }
        _unitOfWork.Save();
        
        
        _unitOfWork.Items.Create(itemElectronics1);
        _unitOfWork.Items.Create(itemElectronics2);
        _unitOfWork.Items.Create(itemElectronics3);
        _unitOfWork.Items.Create(itemElectronics4);
        _unitOfWork.Items.Create(itemElectronics5);
        _unitOfWork.Items.Create(itemElectronics6);
        _unitOfWork.Save();
    }
}
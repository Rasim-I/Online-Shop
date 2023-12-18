﻿using OnlineShopDAL.Entities;
using OnlineShopDAL.Entities.Enums;
using OnlineShopDAL.Entities.ItemTypes;

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
        /*
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
        */
        
        CategoryEntity categoryElectronics = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Electronics, IsRoot = true};
        CategoryEntity categorySport = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Sport, IsRoot = true};
        CategoryEntity categoryDecorations = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Decorations, IsRoot = true};
        CategoryEntity categoryClothes = new CategoryEntity()
            { Id = Guid.NewGuid(), Name = CategoryNames.Clothes, IsRoot = true};


        List<PhotoEntity> photosForElectronics1 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics11",
                Link = "https://drive.google.com/uc?id=11HB5-DTRx6aSyoZZ0CzNU93NUi6W2SeC",
                IsMain = true
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics12",
                Link = "https://drive.google.com/uc?id=1iAhrxC0gRnM_hz5EaD-O99mK2XxEytc7"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics13",
                Link = "https://drive.google.com/uc?id=1fXkHxp36yEb6y04salvOYEj69OXyiqWN"
            }
        };
        List<PhotoEntity> photosForElectronics2 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics21",
                Link = "https://drive.google.com/uc?id=1lwDpRSgwHqr0TGNXt7ie14k2rb-14dhs",
                IsMain = true
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics22",
                Link = "https://drive.google.com/uc?id=18FY6MjfPru6MLEtOGzNGM93NxAQEvSsX"
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics23",
                Link = "https://drive.google.com/uc?id=1lHzLtcij3hzo_MhwTC7jTaWwyhAG5xow"
            }
        };
        List<PhotoEntity> photosForElectronics3 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics31",
                Link = "https://drive.google.com/uc?id=1lV0dGV6Oes1aQulx-xJG4fnzdpW7nGMj",
                IsMain = true
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics32",
                Link = "https://drive.google.com/uc?id=1BHyHccQr8dUWpbkCQ0iGA5Yk_Fe9Jq6o"
            }
        };
        List<PhotoEntity> photosForElectronics4 = new List<PhotoEntity>()
        {
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics41",
                Link = "https://drive.google.com/uc?id=1BEeOQ5SDRfbQI3f1i_kfU5qe-WL0QCXO",
                IsMain = true
            },
            new PhotoEntity()
            {
                Id = Guid.NewGuid(), Name = "Electronics42",
                Link = "https://drive.google.com/uc?id=1TCY_U7zMZNh6-zl6_OLfoOrRf6Bu5ZXH"
            }
        };

        ItemEntity itemElectronics1 = new ItemElectronicsEntity()
        {
            Id = Guid.NewGuid(), Name = "Laptop model something Silver Grey",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1200, Quantity = 10, Photos = photosForElectronics1, CpuModel = "Amd", MemoryCapacity = 256
        };

        ItemEntity itemElectronics2 = new ItemElectronicsEntity()
        {
            Id = Guid.NewGuid(), Name = "Laptop 2 model something Silver Grey",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1400, Quantity = 8, Photos = photosForElectronics2, CpuModel = "Intel", MemoryCapacity = 256
        };


        ItemEntity itemElectronics4 = new ItemElectronicsEntity()
        {
            Id = Guid.NewGuid(), Name = "Tablet model something Matte Gray",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sequis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1000, Quantity = 5, Photos = photosForElectronics3, CpuModel = "Qualcomm", MemoryCapacity = 128
        };

        ItemEntity itemElectronics5 = new ItemElectronicsEntity()
        {
            Id = Guid.NewGuid(), Name = "Tablet 2 model something Silver Gray",
            Description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sequis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            Category = categoryElectronics, Price = 1100, Quantity = 4, Photos = photosForElectronics4, CpuModel = "MediaTech", MemoryCapacity = 128
        };
        
        
        List<CategoryEntity> categories = new List<CategoryEntity>();
        categories.Add(categoryElectronics);
        categories.Add(categoryDecorations);
        categories.Add(categorySport);
        categories.Add(categoryClothes);

        List<ItemEntity> items = new List<ItemEntity>();
        items.Add(itemElectronics1);
        items.Add(itemElectronics2);
        items.Add(itemElectronics4);
        items.Add(itemElectronics5);

        /*
        _unitOfWork.Photos.Create(photoDecorations);
        _unitOfWork.Photos.Create(photoElectronics);
        _unitOfWork.Photos.Create(photoClothes);
        _unitOfWork.Photos.Create(photoSport);
        _unitOfWork.Save();
    
        */
        
        _unitOfWork.Categories.Create(categoryElectronics);
        _unitOfWork.Categories.Create(categorySport);
        _unitOfWork.Categories.Create(categoryDecorations);
        _unitOfWork.Categories.Create(categoryClothes);
        _unitOfWork.Save();
        
        foreach (var photo in photosForElectronics1)
        {
            _unitOfWork.Photos.Create(photo);
        }
        foreach (var photo in photosForElectronics2)
        {
            _unitOfWork.Photos.Create(photo);
        }
        foreach (var photo in photosForElectronics3)
        {
            _unitOfWork.Photos.Create(photo);
        }        foreach (var photo in photosForElectronics4)
        {
            _unitOfWork.Photos.Create(photo);
        }
        _unitOfWork.Save();
        
        
        _unitOfWork.Items.Create(itemElectronics1);
        _unitOfWork.Items.Create(itemElectronics2);
        _unitOfWork.Items.Create(itemElectronics4);
        _unitOfWork.Items.Create(itemElectronics5);
        _unitOfWork.Save();
    }
}
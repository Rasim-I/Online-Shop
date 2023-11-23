﻿using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Category
    {
        private Guid _id;
        private CategoryNames _name;
        private List<Item> _items;
        private List<Category> _subCategories;

        public List<Category> SubCategories
        {
            get => _subCategories;
            set => _subCategories = value;
        }

        public Guid Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public CategoryNames Name
        {
            get => _name;
            set => _name = value;
        }

        /*
        public List<Item> Items
        {
            get => _items;
            set => _items = value;
        }
    */
        

        public Category(CategoryNames name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _items = new List<Item>();
            _subCategories = new List<Category>();
        }
        
        public Category(){}
    }

}
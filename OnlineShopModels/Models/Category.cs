﻿using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;
using OnlineShopModels.Models.Enums;

namespace OnlineShopModels.Models
{
    public class Category
    {
        private Guid _id;
        private CategoryName _name;
        //private List<Item> _items;
        private Guid _rootCategory;
        private bool _isRoot;

        public Guid RootCategory
        {
            get => _rootCategory;
            set
            {
                _rootCategory = value;
                _isRoot = false;
            }
        }

        public bool IsRoot
        {
            get => _isRoot;
            set => _isRoot = value;
        }
        
        public Guid Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public CategoryName Name
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
        

        public Category(CategoryName name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _isRoot = true;
            //_items = new List<Item>();
        }
        
        public Category(){}
    }

}
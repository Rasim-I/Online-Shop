using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Category
    {
        private Guid _id;
        //private CategoryNames _name;
        //private Item _item;
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

        /*
        public CategoryNames Name
        {
            get => _name;
            set => _name = value;
        }
        */
        
        /*
        public Item Item
        {
            get => _item;
            set => _item = value;
        }
        */
        

        public Category(Guid itemId)
        {
            _id = Guid.NewGuid();
            //_name = name;
            _isRoot = true;
            //_item = item;
        }
        
        public Category(){}
    }

}
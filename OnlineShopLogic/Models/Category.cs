using System;
using System.Collections.Generic;

namespace OnlineShopLogic.Models
{
    public class Category
    {
        private Guid _id;
        private string _name;
        private List<Item> _items;
        private Photo _photo;
        private List<Category> _subCategories;
        private Category _primaryCategory;

        public List<Category> SubCategories
        {
            get => _subCategories;
            set => _subCategories = value;
        }

        public Category PrimaryCategory
        {
            get => _primaryCategory;
            set => _primaryCategory = value;
        }

        public Guid Id => _id;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public List<Item> Items
        {
            get => _items;
            set => _items = value;
        }

        public Photo Photo
        {
            get => _photo;
            set => _photo = value;
        }

        public Category(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _items = new List<Item>();
            _subCategories = new List<Category>();
        }
        
    }

}
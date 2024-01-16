using System;
using System.Collections.Generic;
using OnlineShopModels.Models.ItemTypes;

namespace OnlineShopModels.Models
{
    public class Item
    {
        private Guid _id;
        private int _price;
        private string _brand;
        private string _name;
        private string _description;
        private List<Photo> _photos;
        private int _quantity;
        private Category _category;

        /*
        private string _itemType;

        public string ItemType
        {
            get => _itemType;
            protected set => _itemType = value;
        }
        */
        
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public string Brand
        {
            get => _brand;
            set => _brand = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public List<Photo> Photos
        {
            get => _photos;
            set => _photos = value;
        }

        public int Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public Category Category
        {
            get => _category;
            set => _category = value;
        }

        public Item(string name, string description, int price, Category category, int quantity)
        {
            _id = Guid.NewGuid();
            _name = name;
            _description = description;
            _price = price;
            _category = category;
            _quantity = quantity;
            _photos = new List<Photo>();
        }

        public Item()
        {
            //_itemType = "Item";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Item otherItem = (Item)obj;
            return Id == otherItem.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
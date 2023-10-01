using System;
using System.Collections.Generic;

namespace OnlineShopLogic.Models
{
    public class Item
    {
        private Guid _id;
        private int _price;
        private string _name;
        private string _description;
        private List<Photo> _photos;
        private int _quantity;
        private Guid _categoryId;

        public Guid Id => _id;

        public int Price
        {
            get => _price;
            set => _price = value;
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

        public Guid CategoryId
        {
            get => _categoryId;
            set => _categoryId = value;
        }

        public Item(string name, string description, int price, Guid categoryId, int quantity)
        {
            _id = Guid.NewGuid();
            _name = name;
            _description = description;
            _price = price;
            _categoryId = categoryId;
            _quantity = quantity;
            _photos = new List<Photo>();
        }
        
    }
}
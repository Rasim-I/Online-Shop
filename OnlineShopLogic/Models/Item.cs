﻿using System;
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
        private Category _category;

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
        
        public Item(){}
    }
}
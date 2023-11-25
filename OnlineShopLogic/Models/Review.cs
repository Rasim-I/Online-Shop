using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Review
    {
        private Guid _id;
        private Customer _customer;
        private Item _item;
        private string _text;
        private Stars _stars;
        private DateTime _reviewDate;
        private List<Photo> _photos;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public Item Item
        {
            get => _item;
            set => _item = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public Stars Stars
        {
            get => _stars;
            set => _stars = value;
        }

        public DateTime ReviewDate
        {
            get => _reviewDate;
            set => _reviewDate = value;
        }

        public List<Photo> Photos
        {
            get => _photos;
            set => _photos = value;
        }

        public Review(Customer customer, Item item, string text, Stars stars, DateTime reviewDate)
        {
            _id = Guid.NewGuid();
            _customer = customer;
            _item = item;
            _text = text;
            _stars = stars;
            _reviewDate = reviewDate;
            _photos = new List<Photo>();
        }
        
        public Review(){}
        
    }
}